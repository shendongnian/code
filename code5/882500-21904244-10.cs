    class MainForm : Form
    {
        // ... other code
        
        public MainForm()
        {
            // ... other code
            
            // Assume this is assigned to the factory that you want to get all the workstations for
            Factory myFactory;
            var workstations = myFactory.GetAllWorkstations();
            // Now you can use 'workstations' as the items source for a list, for example.
        }
    }
