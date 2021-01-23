    class ProjectExt : IExtension<Project>
    {
        Project project;
    
        public DelegateCommand OpenProjectCommand { get { ... } }
        public DelegateCommand SaveProjectCommand { get { ... } }
        public DelegateCommand CloseProjectCommand { get { ... } }
    
        public bool IsSelected { get { ... } set { ... } }
    
        ...
    }
