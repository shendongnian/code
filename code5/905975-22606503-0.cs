    class myGenericClass<T> where T : Person, IEquatable<T>
    {
        public void Eq(T t1, T t2)
        {
           Console.WriteLine(t1.Equals(t2));
        }
    }
    class Person : IEquatable<Person>
    {
        public  bool Equals(Person p)
        {
            return true;
        }
    }
    class Student : Person, IEquatable<Student>
    {
        public  bool Equals(Student s)
        {
            return true;
        }
    }
