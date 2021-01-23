    public class FormParent : Form
    {
 
        public void OpenChild()
        {
            // create the child form
            FormChild child = new FormChild();
            // register the event
            child.DataUpdated += Child_DataUpdated;
            // ....
            
            // parent to child (method call)
            child.DoSomething();
        }
 
        public void Child_DataUpdated(object sender, EventArgs e)
        {
             // refresh the list.
        }
    }
    public class FormChild : Form
    {
        public void DoSomething()
        {
            // ....
            // if the list should be refreshed.
            // call event from child to parent.
            if(DataUpdated != null)
                DataUpdated(this, EventArgs.Empty);
        }
      
        public event EventHandler DataUpdated;
    }
