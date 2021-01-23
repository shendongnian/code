    class MainClass
    {
        Control control1;
        public void TestMethod()
        {
            control1 = new Control();
            Status control1Status = control1.GetStatus();
        }
    }
    class Status
    {
        public Status(Control control)
        {
            //do status Initiation
            IsValid = true //or false
        }
        public bool IsValid
        {
            get;
            private set;
        }
    }
    class Control
    {
        public Status GetStatus()
        {
            return new Status(this);
        }
    }
