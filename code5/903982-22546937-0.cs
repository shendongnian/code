    public class ProjectDataService : IProjectDataService
    {
        private static IProjectModel _projectModel;
    
        public IProjectModel Create(string fileName)
        {
            if (_projectModel == null)
            {
                //create it
            }
            return _projectModel;
          }
     }
