     public class TestRow
    {
        public Dictionary<string,float> Field { get; set; }
        public TestRow()
        {
            this.Field = new Dictionary<string, float>();
            this.Field.Add("ColumnA", 2);
            this.Field.Add("ColumnB", 3);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            var testRow = new TestRow();
            string expressionString = "r.Field[\"ColumnA\"] * r.Field[\"ColumnB\"]";
            var parameter = Expression.Parameter(typeof(TestRow),"r");
            var lambdaET = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { parameter }, typeof(float), expressionString);
            
            var result = lambdaET.Compile().DynamicInvoke(testRow);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
