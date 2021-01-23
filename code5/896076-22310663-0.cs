    public class IndexCalledEventArgs : EventArgs
    {
        public IndexCalledEventArgs(int index)
        {
            Index = index;
        }
        public int Index { get; private set; }
    }
