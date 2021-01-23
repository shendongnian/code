     class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            Type t = p.Enuminator.GetType();
            dynamic e = Activator.CreateInstance(t);
            FieldInfo [] FieldArray = t.GetFields();
            p.GetType().GetField("Enuminator").SetValue(p, FieldArray[3].GetValue(e));
            Console.WriteLine(p.Enuminator);
            Console.Read();
        }
    }
    public class Person{
        public String name = "";
        public Person Parent;
        public Enumtest Enuminator;
        public Person()
        {
        }
        public Person(String s)
        {
            name = s;
        }
    }
    public enum Enumtest
    {
        chicken,
        monkey,
        frog
    }
