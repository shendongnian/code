    class MainClass
    {
        public Status status1;
        public Control control1;
    }
    class Status
    {        
        public void testStatus(Control control)
        {
            control.testControl();
        }
    }
    class Control
    {
        public void testControl()
        {
        }
    }
