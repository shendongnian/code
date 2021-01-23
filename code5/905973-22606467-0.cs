    class Person
    {
        public virtual bool Equals(Person p)
        {
            return true;
        }
    }
    class Student : Person
    {
        public override bool Equals(Person obj)
        {
            return true;
        }
    }
