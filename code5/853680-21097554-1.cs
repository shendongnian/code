    public partial class App : Application
    {
        public new void Run()
        {
            // Do your stuff here
            B.DoStuff();
            // Call the base method
            base.Run();
        }
    }
