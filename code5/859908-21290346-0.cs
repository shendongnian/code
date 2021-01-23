    namespace CoreLibrary
    {
        public class MyCoreApplication : System.Windows.Application
        {
             // A container the parent library can access
             protected CoreLibrary.AppSettings Settings { get; set; }
             public MyCoreApplication()
             {
                 this.Settings = new CoreLibrary.AppSettings();
             }
        }
    }
    namespace ReferencingLibrary
    {
        public class AppSettings : CoreLibrary.AppSettings
        {
            // Derived implementation
        }
        public class MyDerivedApplication : CoreLibrary.MyCoreApplication
        {
            public MyDerviedApplication() : base()
            {
                 // Overwrite the default assignment from the parent class with a new assignment
                 this.Settings = new ReferencingLibrary.AppSettings();
            }
        }
    }
