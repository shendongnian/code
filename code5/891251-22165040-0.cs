    public class MyListClass : List<Log>
    {
        public void Add(string message, Log.LogTypes logType)
        {
            this.Add(new Log(message, logType));
        }
    }
