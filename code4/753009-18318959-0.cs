    public class MySaveCompleteEventArgs : EventArgs
    {
        public MySaveCompleteEventArgs(int id)
        {
           ID = id;
        }
    
        public int ID { get; private set; }
    }
