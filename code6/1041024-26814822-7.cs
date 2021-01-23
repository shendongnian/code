    public class ProjectViewModel : Screen{
      private Project _project;
      public ProjectViewModel(Project project){
    
        DisplayName = "Test" ;
        
        Project = project;
      }  
      public Project Project{
           get{ return _project;}
           private set{
               _project = value;
               NotifyOfPropertyChange();
           }
        }
     }
