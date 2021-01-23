    interface A
    {
        // The interface requires that Text is *at least* read only
        string Text { get; }
    }
    
    class B : A
    {
        string text = "";
        // Implement Text as read-write
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }
