    internal class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            // ERROR: "an object reference is required for the non-static
            //         field, method, or property ProgramBase.MainWrapper();"
            MainWrapper();
        }
        protected override void DoMain()
        {
            // do something
        }
    }
    internal abstract class ProgramBase
    {
        protected void MainWrapper()
        {
            try
            {
                // do some stuff
                DoMain();
            }
            catch(...)
            {
                // handle some errors
            }
        }
        protected abstract void DoMain();
    }
