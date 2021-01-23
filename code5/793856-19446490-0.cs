    public class Base
    {
        private int value = 5;
        public int GetValue()
        {
            return value;
        }
    }
    public class Inherited : Base
    {
        public void PrintValue()
        {
            Console.WriteLine(GetValue());
        }
    }
    static void Main()
    {
        new Inherited().PrintValue();//prints 5
    }
