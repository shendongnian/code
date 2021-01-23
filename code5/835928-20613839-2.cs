    public enum BloodTestType{ H1AC,Glucose }
    
    public class BloodTest: LabTest
    {        
        public override void Run<TInput>(TInput input) 
        {
            Console.WriteLine("BloodTest: {0}",input);            
        }
    }
    
    public class BloodTestFactory : LabTestFactory
    {
        public override LabTest CreateLabTest()
        {
            return new BloodTest();
        }
    }
    
    public enum UrineTestType{ A,B }
    public class UrineTest: LabTest
    {        
        public override void Run<TInput>(TInput input) 
        {
            Console.WriteLine("UrineTest: {0}",input);            
        }
    }
    
    public class UrineTestFactory : LabTestFactory
    {
        public override LabTest CreateLabTest()
        {
            return new UrineTest();
        }
    }
            
