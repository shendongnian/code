    public class LabTestClient
    {        
        public void Run<TFactory, TInput>(TInput input) where TFactory : LabTestFactory, new()
        {
            LabTestFactory factory = new TFactory();;
            LabTest labTest = factory.CreateLabTest();
            labTest.Run(input);
        }
        
    }
    
    public abstract class LabTest
    {        
        public abstract void Run<TInput>(TInput input);
    }
    
    public abstract class LabTestFactory
    {
        public abstract LabTest CreateLabTest();
    }
