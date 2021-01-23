    class Dog
    {
        public string name { get; set; }
        public int health = 100;
        public Dog(string theName)
        {
            name = theName;
        }
        
        public void Attack(Dog theDog)
        {
            Console.WriteLine("{0} attacks {1}.", this.name, theDog.name);
            LoseHealth(theDog);
        }
        public void LoseHealth(Dog theDog)
        {
            Console.WriteLine("{0} loses health!", theDog.name);
            theDog.health -= 5;
        }
    }
