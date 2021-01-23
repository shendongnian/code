    class Person
    {
        public int Age;
        public static T IncrementAge<T>(T p) where T : Person
        {
            p.Age++;
            return p;
        }
    }
