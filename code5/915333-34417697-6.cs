    public class TestPlugin: IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            try
            {
                OtherMethod();
            }
            catch (Exception ex)
            {
                var trace = (ITracingService)serviceProvider.GetService(typeof (ITracingService));
                trace.Trace("Throwing Plugin");
                // Doesn't work
                throw new InvalidPluginExecutionException("Error ", ex);
            }
        }
        // Works:
        //public void Execute(IServiceProvider serviceProvider)
        //{
            //try
            //{
                //OtherMethod();
            //}
            //catch (Exception ex)
            //{
                //var trace = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
                //trace.Trace("Throwing Plugin");
                //throw new InvalidPluginExecutionException("Error " + ex);
            //}
        //}
        // Doesn't Work:
        //public void Execute(IServiceProvider serviceProvider)
        //{
        //    try
        //    {
        //        OtherMethod();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        // Doesn't Work:
        //public void Execute(IServiceProvider serviceProvider)
        //{
        //    try
        //    {
        //        OtherMethod();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new InvalidPluginExecutionException("Error", ex);
        //    }
        //}
        public void OtherMethod()
        {
            throw new MyException();
        }
    }
    public class MyException : Exception
    {
        
    }
