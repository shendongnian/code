    static void Main(string[] args)
    {
      var s1 = new Student();
      var s2 = new Student();
      myGenericClass<Student> Mgc = new myGenericClass<Student>();
      Mgc.Eq(s1, s2);
      
      var p1 = new Person();
      var p2 = new Person();
      myGenericClass<Person> Pgc = new myGenericClass<Person>();
      Pgc.Eq(p1, p2);
    }
    class myGenericClass<T> where T : IFoo<T>
    {
       public void Eq(T t1, T t2)
       {
          Console.WriteLine(t1.Equals(t2));
       }
    }
    interface IFoo<T>
    {
        bool Equals(T t);
    }
    class Person : IFoo<Person>
    {
       public bool Equals(Person p)
       {
           return true;
       }
    }
    class Student : IFoo<Student>
    {
        public bool Equals(Student obj)
       {
           return false;
       }
    }
