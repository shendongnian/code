    public class Test
    {
        private void RunTests()
        {
            Test(new WcfFactory());
    
            Test(new UnityContainerFactory());
        }
    
        private void Test(IMyServiceFactory factory)
        {
            var mysvc = factory.GetService<MyServiceContract>();
    
            var returnmessage = mysvc.GetData(9);
            Console.WriteLine(returnmessage);
        }
    }
