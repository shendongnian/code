            void RWDeviceState(int i)
        {
            try
            {
                int TempID = i;
                long StartTime;
                long NextTime;
                long Period = 3000;
                int ID = 0;
                bool State = false;
                long WT = 0;
                int ParID = 0;
                bool Save = false;                
                while (ExecutionAllowed)
                {
                    Save = false;
                    ReadStates(TempID, out ID, out State, out WT, out ParID, out Save);
                    lock (locker)
                    {
                        if (Save) WriteState(ID, State, WT, ParID);
                    }
                    StartTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    NextTime = StartTime + Period;
                    while (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond < NextTime && ExecutionAllowed)
                    {
                        Thread.Sleep(40);
                    }
                }
