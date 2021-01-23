    public void StartLogging(object connection)
    {
        var ctxt = Singleton.Instance.Context();
        var publisher = ctxt.Socket(ZMQ.SocketType.PUB);
        publisher.Bind("tcp://127.0.0.1:5000");
        if (connection is uint)
        {
            Console.WriteLine("strange");
            Console.ReadLine();
        }
    }
	public sealed class Singleton
	{
		private static readonly ZMQ instance = new ZMQ();
		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static Singleton()
		{
		}
		private Singleton()
		{
		}
		public static Singleton Instance
		{
			get
			{
				return instance;
			}
		}
	}
