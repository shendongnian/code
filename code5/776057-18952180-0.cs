     public partial class App : Application
    {
        public App()
        {
            string connectionStr = "Data Source=system\\SQLExpress;Initial Catalog=DBName; user id=sa; password=test123;";
            Application.Current.Properties["conStr"] = connectionStr;
        }
    }
