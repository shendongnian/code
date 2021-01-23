    public class ViewModel : INotifyPropertyChanged
    {
        RevisionModelContainer context = new RevisionModelContainer();
    
        public ViewModel() 
        {
            Customers = context.Customers.Include("Project");
        }
    
        public IEnumerable<Customer> Customers { get; private set; }
    
        public IEnumerable<Project> Projects { get; private set; }
    
        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get 
            { 
                return selectedCustomer; 
            }
            set
            {
                selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
    
                // reset the projects.
                this.SelectedProject = null;
                this.Projects = selectedCustomer.Projects;
                OnPropertyChanged("Projects");
            }
        }
    
        private Project selectedProject;
        public Project SelectedProject
        {
            get 
            { 
                return selectedProject; 
            }
            set
            {
                selectedProject = value;
                OnPropertyChanged("SelectedProject");
            }
        }
    }
