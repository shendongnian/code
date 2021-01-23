    public class NewTitleEventArgs : EventArgs
    {
        public string NewTitle { get; private set; }
        public NewTitleEventArgs(string title)
        {
            NewTitle = title;
        }
    } 
    
    public event EventHandler<NewTitleEventArgs> NewTitle;
