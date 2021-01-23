	private static object gate = new object();
	
    public static void theVoid(int ID)
    {
		lock (gate)
		{
			//<THREADS WAIT STATION>
			//ACTIONS
			//ACTIONS
			//<ONE THREAD STILL PROCESSING>
			Console.WriteLine("Test");
		}
    }
