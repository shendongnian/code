        public LogList : List<Log>
        {
            public void Add(string message, LogType type)
            {
                Add(new Log(message, type));
            }
        }
