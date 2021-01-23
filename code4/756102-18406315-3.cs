    class Program
    {
        static void Main(string[] args)
        {
            object d = new Person();
            d.GetType().GetField("Parent").SetValue(d,new Person("Test"));
            Console.WriteLine(((Person)d).Parent.name);
            Console.Read();
        }
    }
    public class Person{
        public String name = "";
        public Person Parent;
        public Person()
        {
        }
        public Person(String s)
        {
            name = s;
        }
    }
