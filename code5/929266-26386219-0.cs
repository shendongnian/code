    public class VisibilityChangedEventArgs : EventArgs
    {
        public Visibility Visibility { get; private set; }
        public VisibilityChangedEventArgs(Visibility visibility)
        {
            this.Visibility = visibility;
        }
    }
