       static void Main(string[] args)
		{
			if (args.Length != 0)
			{
				var server = new AsyncServer();
				server.StartServer();
			}
			else
			{
				for(int i = 0; i < 10; i++)
				{
					var client = new AsyncClient(i);
					client.StartClient();
				}
			}
			Console.WriteLine("Press a key to exit");
			Console.ReadKey();
		}
