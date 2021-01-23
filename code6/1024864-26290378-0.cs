    public class ControlledForm : Form 
    {
        //...        
    
        //This founction will affect the form
        public void DoSomething(int Params)
        {
        //Affect Form
        }
        private void SomethingEventHandler() //function that calls the new form and hides this one
        {
            //Give the construction this (the instance of the form) in parameter
            ControllerForm newControllerForm = new ControllerForm(this);
            newControllerForm.Show();
            this.Hide();
        }
    }
    public class ControllerForm : Form
    {
        //Constructor that receives the instance of the controlled form in parameter
        public ControllerForm(ControlledForm CF)
        {
            _ControlledForm = CF;
            InitializeComponents();
        }
        private ControlledForm _ControlledForm;
        private void SomethingElseEventHandler() //Function that modifies the controlled form
        {
            //This will effectively affect the form
            _ControlledForm.DoSomething(12);
        }    
    }
