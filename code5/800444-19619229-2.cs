    public partial class App : Application
    {
        static App()
        {
            MyViewModel = new MyViewModel();
        }
        public static MyViewModel MyViewModel { get; set; }
    }
