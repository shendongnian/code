     public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MyEnum.Bar.Name());
            foreach(MyEnum e in Enum.GetValues(typeof(MyEnum)))
            {
                EnumTest(e);
            }           
        }
        public static void EnumTest(MyEnum e)
        {
            Console.WriteLine(
               String.Format("{0}'s name={1}: num={2}", e.Title(), e.Name(), e.Num()));
        }
    }
