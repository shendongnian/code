    public interface IExtension<T>
    {
        void Initialize(T target);
    }
    // model class
    public class Project
    {
        ...
        public IExtension<Project> Gui
        {
            get { return serviceProvider.Get<Project>(this); } 
        }
    }
    
    // model class
    public class Application
    {
        ...
        public ObservableCollection<Projects> Projects { get { ... } }
        public IExtension<Application> Gui
        {
            get { return serviceProvider.Get<Application>(this); } 
        }
    }
