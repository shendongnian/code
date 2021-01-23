    namespace BaseProject
    {
        public class MyBaseApplication : System.Windows.Application
        {
             // A container the parent library can access
             protected BaseProject.AppSettings Settings { get; set; }
             public MyBaseApplication()
             {
                 this.Settings = new BaseProject.AppSettings();
             }
        }
    }
    namespace ChildProject
    {
        public class AppSettings : BaseProject.AppSettings
        {
            // Derived implementation
        }
        public class MyChildApplication : BaseProject.MyBaseApplication
        {
            public MyChildApplication() : base()
            {
                 // Overwrite the default assignment from the parent class with a new assignment
                 this.Settings = new ChildProject.AppSettings();
            }
        }
    }
