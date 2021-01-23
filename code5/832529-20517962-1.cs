    public delegate void UpdatedEventHandler(object sender, EventArgs e);
    public class SomeController {
        public event UpdatedEventHandler Updated;
        protected virtual void OnUpdated(EventArgs e) 
        {
            if (Updated != null)
            {
                this.Updated(this, e);
            }
        }
        public void DoSomething()
        {
            // Do stuff
            this.OnUpdated(new EventArgs());
        }
    }
    public class SomeView implements Observer{
        private SomeController controller;
        public SomeView(SomeController ctrl)
        {
            this.controller = ctrl;
            ctrl.Changed += this.OnControllerChanged;
        }
        private void OnControllerChanged(object sender, EventArgs e)
        {
            if (sender == this.controller)
            {
                Console.WriteLine("Update detected");
            }
        }
    }
