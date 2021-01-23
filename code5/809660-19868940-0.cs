    public class ClassB
    {
        private string ConstValue {get; set;}
        public GetConstValue(string constValue)
        {
           ConstValue = constValue;
        }
    }
    public class Person
    {
       private const string MyConst = "A";
       public ProvideConstValue(ClassB obj)
       {
           //todo: contract validations
           obj.GetConstValue(MyConst);
       }
    }
