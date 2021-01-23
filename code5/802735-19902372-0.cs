    class Overview : Base
    {
        public Command.FocusUIElement Focus
        {
            get;
            private set;
        }
    
        public Overview( )
        {
            this.Focus = new Command.FocusUIElement();
        }
    }
