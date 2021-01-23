	static readonly ConnectionFactory Factory = new ConnectionFactory { HostName = "localhost" };
	static readonly IConnection Connection = Factory.CreateConnection();
	static QueueingBasicConsumer consumer;
	static IModel agentChannel;
	static CancellationTokenSource _tokenSource;
	
	static void Main(string[] args)
	{
		_tokenSource = new CancellationTokenSource();
		const string queueName = "testQueue";
		agentChannel = Connection.CreateModel();
		agentChannel.QueueDeclare(queueName, true, false, false, null);
		agentChannel.QueueBind(queueName, "testExchange", "");
		consumer = new QueueingBasicConsumer(agentChannel);
		agentChannel.BasicConsume(queueName, false, consumer);
		while (!_tokenSource.Token.IsCancellationRequested)
		{
			DequeueMessages();
		}
		Console.ReadLine();
		_tokenSource.Cancel();
	}
	static void DequeueMessages()
	{
		ThreadPool.SetMaxThreads(200, 200);
		ThreadPool.SetMinThreads(200, 200);
		var ea = consumer.Queue.Dequeue();
		ThreadPool.QueueUserWorkItem(ProcessWorkInThread, ea);
	}
	static void ProcessWorkInThread(object state)
	{
		var ea = state as BasicDeliverEventArgs;
		var message = Encoding.UTF8.GetString(ea.Body);
		var settings = new JsonSerializerSettings();
		settings.ContractResolver = new DefaultContractResolver()
		{
			DefaultMembersSearchFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public
		};
		var item = JsonConvert.DeserializeObject<string>(message, settings);
		Console.WriteLine(item);
		Thread.Sleep(10000); //simulate work
		lock (agentChannel)
			agentChannel.BasicAck(ea.DeliveryTag, false);
	}
