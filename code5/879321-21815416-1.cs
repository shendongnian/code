        public class PermeabilityTest
        {
            //volatile alerts the compiler that it will be used across threads.
            private volatile bool aborted;
            public event ProgressEventHandler Progress;
            public void RequestStop()
            {
                //handle saving data file here as well.
                aborted = true;
            }
            public void RunTest()
            {
                //reference the comms class so we can communicate with the machine
                PMI_Software.COMMS COM = new COMMS();
                //some test stuffs here
                int x = 0;
                while (x < 100 && !aborted)
                {
                    // Report on progress
                    if(Progress != null)
                    {
                        Progress("This message will appear in ListBox");
                    }
                    System.Diagnostics.Debug.Write("Well here it is, running it's own thread." + Environment.NewLine);
                    COM.Pause(1);
                }
            }
        }
