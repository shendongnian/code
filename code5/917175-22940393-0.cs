    class Program
    {
        static void Main(string[] args)
        {
            B a1 = new A<Person>();
            B a2 = new A<ChildPerson>();
        }
    }
    class Person
    {
    }
    
    class ChildPerson : Person
    {
    }
    class A<T> : B where T: Person
    {
    }
    class B
    {
    }
