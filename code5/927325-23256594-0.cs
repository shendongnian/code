    class Human
    {
        public string Name;
        public int Age;
        public Human( string name, int age )
        {
            Name = name;
            Age = age;
        }
        public static implicit operator Doggy( Human human )
        {
            return new Doggy( human.Name, human.Age / 7 );
        }
    }
    class Doggy
    {
        public string Name;
        public int Age;
        public Doggy( string name, int age )
        {
            Name = name;
            Age = age;
        }
        public static implicit operator Human( Doggy dog )
        {
            return new Human( dog.Name, dog.Age * 7 );
        }
    }
