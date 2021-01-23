    class Program  
    { 
        static void Main(string[] args)
        {
            Teacher Teacher = new Teacher();
            ((Person)Teacher).ShowInfo();    //"I am Person"
            Teacher.ShowInfo();              //"I am Teacher"
            Console.ReadLine();
        }
    }
    public class Person
    {
        public virtual void ShowInfo()
        {
            Console.WriteLine("I am Person");
        }
    }
    public class Teacher : Person
    {
        public new void ShowInfo()
        {
            Console.WriteLine("I am Teacher");
        }
    }  
