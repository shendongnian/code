		public class MySyncProc
		{
			/// <summary>
			/// Value returned from the process after completion
			/// </summary>
			public string Result = null;
			
			...other shared data...
			public MySyncProc() { }
			public void Run()
			{
				Result = LengthyProcess(...);
				return;
			}
		}
        public string Run(int TimeoutMs)
        {
            MySyncProc SyncP = new MySyncProc() { arg1 = ..., etc };
            //
            Thread T = new Thread(SyncP.Run);
            T.Start();
            //
            DateTime StopTime = DateTime.Now.AddMilliseconds(TimeoutMs);
            while (DateTime.Now < StopTime && SyncP.Result == null)
            {
                Thread.Sleep(200);
            }
            if (T.IsAlive)
            {
                T.Abort();
                Console.WriteLine("Aborted thread for: {0}", Name);
            }
            return SyncP.Result;
        }
