        public class SerialReader
        {
            public Action<string> Callback;
            public void Read()
            {
                if (Callback != null)
                    Callback("Here is a message for the status bar");
                
            }
        }
