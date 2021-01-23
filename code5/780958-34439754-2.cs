    class Program
    {
        static void Main(string[] args)
        {
            var myApp = new MyApplication();
            myApp.RunApp();
        }
    }
    public class MyApplication : ApplicationBase
    {
        protected override void DoRunApp()
        {
            // do my stuff
        }
    }
    public abstract class ApplicationBase
    {
        public void RunApp()
        {
            try
            {
                // create AppDomain, or some other construction stuff
                // do some stuff
                DoRunApp();
            }
            catch(...)
            {
                // handle some errors
            }
            catch(...)
            {
                // handle some other errors
            }
        }
        protected abstract void DoRunApp();
    }
