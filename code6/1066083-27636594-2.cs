    public class MasterSaveEventArgs : EventArgs
    {
        public int Index { get; private set; }
        public MasterSaveEventArgs(int index)
        {
            this.Index = index;
        }
    }
