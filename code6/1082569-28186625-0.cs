    class ExPanel : Panel
    {
        public int PreferredHeight
        {
            get;
            private set;
        }
        public ExPanel(int preferredHeight)
            : base()
        {
            PreferredHeight = preferredHeight;
        }
    }
