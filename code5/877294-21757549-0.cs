    public class ListProcessor
    {
        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
    
        public void Process()
        {
            //...code logic
            if (ProgressChanged != null)
                ProgressChanged(this, new ProgressChangedEventArgs(1, this));
        }
    
    }
