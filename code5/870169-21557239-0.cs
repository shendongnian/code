    class ControlA
    {
        public ControlA(bool subscribe = true)
        {
            if (subscribe)
            {
                this.PreviewKeyDown += ControlA_PreviewKeyDown;
            }
        }
        protected void ControlA_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // do A things
        }
    }
    
    class ControlB : ControlA
    {
        public ControlB() : base(false)
        {
            //some code
            this.PreviewKeyDown += ControlB_PreviewKeyDown;
        }
        protected void ControlB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // do B things
        }
    }
