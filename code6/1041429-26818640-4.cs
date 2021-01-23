    public class Loader : MarshalByRefObject
    {
        public bool IsCompleted { get; private set; }
        public bool IsFaulted  { get; private set; }
        public void LoadAndRunBadAssembly()
        {
            var ass = Assembly.LoadFrom("BadAssembly.dll");
            var c = (Processor)ass.CreateInstance("BadAssembly.Processor");
            Task.Factory.StartNew(() =>
                {
                    try
                    {
                        c.Run();
                        IsCompleted = true;
                    }
                    catch (Exception)
                    {
                        IsFaulted = true;
                    }
                }, TaskCreationOptions.LongRunning);
        }
    } 
