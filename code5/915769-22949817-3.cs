    public class SelectFolderMessage
    {
        public Action<string> CallBack {get;set;}
        public SelectFolderMessage(Action<string> callback)
        {
             CallBack = callback;
        }
    }
