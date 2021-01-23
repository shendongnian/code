    public class Service1 : IService1
    {
         // in an ideal world thisd how instancename would look like
        //ServiceName.ContractName.OperationName@first endpoint listener address
        private static PerformanceCounter pc = new PerformanceCounter();
         // our static constructor
        static Service1()
        {
            // naming of the instance is garbeld due to length restrictions...
            var cat = new PerformanceCounterCategory("ServiceModelOperation 4.0.0.0");
            foreach (var instance in cat.GetInstanceNames())
            {
                Trace.WriteLine(instance); // determine the instancename and copy over :-)
            }
            pc.CategoryName = "ServiceModelOperation 4.0.0.0";
            pc.CounterName = "Calls Per Second";
            pc.InstanceName = "Service1.IServ84.GetDataUsingD31@00:||LOCALHOST:2806|SERVICE1.SVC";
                
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            // do interesting stuff here
            
            // here I have the value (in the service call but you can call this from anywhere, 
            // even from another thread. 
            // or use perfmon.exe to obtain or make a graph of the value over time...
            Trace.WriteLine(pc.NextValue().ToString()); 
            
            return composite;
        }
    }
