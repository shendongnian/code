        public int Age;
        public static T operator ++(Person<T> p)
        {
            return new T { Age = p.Age + 1 };   
        }
    }
    class Agent : Person<Agent> { }
