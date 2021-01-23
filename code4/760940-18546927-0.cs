    public class AddUserEventArgs : EventArgs
    {
        public User AddInfo { get; private set; }
    
        public AddUserEventArgs(User info)
        {
            this.AddInfo = info;
        }
    }
