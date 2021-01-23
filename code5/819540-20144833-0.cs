    public class ProjectOverviewViewModel 
    {
        public IList<ProjectViewModel> Projects { get;set; }
        
        public ProjectViewModel SelectedProject { get;set;}
        
        public void EditSelected() 
        {
           // Code to open edit page for the selected project
        }
     
        public void Print()
        {
        }
    }
