    public class ClassB
    {
        private string ConstValue {get; set;}
        public void SetConstValue(string constValue)
        {
           ConstValue = constValue;
        }
        public void GetConstFromPerson(Person p)
        {
           p.GetConstValue(this);
        }
    }
    public class Person
    {
       private const string MyConst = "A";
       public void GetConstValue(ClassB obj)
       {
           //todo: contract validations
           obj.SetConstValue(MyConst);
       }
    }
