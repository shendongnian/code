    public class Status
    {
        private Control control;
        
        public Status(Control control)
        {
            this.control = control;
        }
    
        public void testStatus()
        {
            this.control.TestControl();
        }
    }
