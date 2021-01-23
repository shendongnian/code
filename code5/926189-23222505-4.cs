    using System;
    namespace Extensibility
    {
        public class ConsoleReader
        {
            public event Action<string> OnCommandEntered;
            public event Action OnQuit;
            private void RaiseOnQuit()
            {
                Action handler = OnQuit;
                if (handler != null) 
                    handler();
            }
            private void RaiseOnCommandEntered(string command)
            {
                Action<string> handler = OnCommandEntered;
                if (handler != null) 
                    handler(command);
            }
            public  void StartReading()
            {
                while (true)
                {
                    var command = Console.ReadLine();
                    if (String.Equals(command, "quit"))
                    {
                        RaiseOnQuit();
                        return;
                    }
                    RaiseOnCommandEntered(command);
                }
            }
        }
    }
