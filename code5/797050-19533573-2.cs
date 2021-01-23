    class Program
    {
        // not sure which other operations, so I just included these two
        public enum OperationCode { EQUALS, BETWEEN }
        
        // made class since it was used that way in your examples
        public class Criterion
        {
            // these have to be declared in the class, instead of the constructor to persist
            public string FieldName;
            public OperationCode Op;
            public object[] Value;
            // made this a property so that it will change automatically with FieldName, Op, and Value
            public string display { get { return String.Format("{0} {1} {2}", FieldName, Op, Value[0]); } }
            // constructor
            public Criterion(string fieldName, OperationCode op, params object[] value)
            {
                FieldName = fieldName;
                Op = op;
                Value = value;
            }
        }
        
        // main program tests with different values
        static void Main(string[] args)
        {
            Criterion c;
            
            c = new Criterion("IsActive", OperationCode.EQUALS, false);
            Console.WriteLine(c.display);
            Console.WriteLine(c.Value[0].GetType().ToString());
            Console.WriteLine();
            
            c = new Criterion("AgeRange", OperationCode.BETWEEN, 18, 35);
            Console.WriteLine(c.display);
            Console.WriteLine(c.Value[0].GetType().ToString());
            Console.WriteLine();
            
            c = new Criterion("TitleString", OperationCode.EQUALS, "This is the title.");
            Console.WriteLine(c.display);
            Console.WriteLine(c.Value[0].GetType().ToString());
            Console.WriteLine();
            
            Console.ReadLine();
        }
    }
