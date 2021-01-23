    public class NewTitleEventArgs : EventArgs
    {
        public string NewTitle { get; private set; }
        public NewTitleEventArgs(string title)
        {
            NewTitle = title;
        }
    } 
    
    public delegate void NewTitleEventHandler(object sender, NewTitleEventArgs args);
    public event NewTitleEventHandler NewTitle;
