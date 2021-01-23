    class Person<T> where T : Person<T>, new()
    {
        public int Age;
        //taking advantage of the fact that the return type might be a specialization
        //of the type implementing the operator
        public static T operator ++(Person<T> p)
        {
            return new T { Age = p.Age + 1 };   
        }
    }
    class Agent : Person<Agent> { }
    //Only required if Person should be usable on it's own
    class Person : Person<Person> { }
