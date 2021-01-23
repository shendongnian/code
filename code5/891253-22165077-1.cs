        public static LogListExtensions
        {
            public static void Add(this Log<List> list, string message, LogType type)
            {
                list.Add(new Log(message, type));
            }
        }
