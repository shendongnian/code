    public class MyComplexClass1
    {
        MyComplexClass1 Property1 {get; }  // requred because cannot be set from outside
        MyComplexClass2 Property2 {get; set;}
        private readonly IService MyService {get; set;}
    
        // no dependency injection frameworks!
        public MyComplexClass1(MyComplexClass1 property1)
        {
           // actually using the constructor to define the required properties
           // MyComplexClass1 is required and MyComplexClass2 is optional
           this.Property1 = property1;
           .....
        }
    
        public ComplexCalculationResult CrazyComplexCalculation(MyComplexClass3 complexity)
        {
           var theAnswer = 42;
           return new ComplexCalculationResult(theAnswer);
        }
    }
