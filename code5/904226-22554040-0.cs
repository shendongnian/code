    	void run();
    }
    
    class  Dog : IPet
    {
        public void run()
        {
            Console.WriteLine("Dog runs");
        }
    }
    class Cat : IPet
    {
        public void run()
        {
            Console.WriteLine("Cat runs");
        }
    }
    class  Human
    {
        public void run(IPet x)
        {
            Console.WriteLine("Human runs");
            x.run();
    
        }
    }
    class Program
    {
        static void Main()
        {
            Dog dog=new Dog();
            Cat cat=new Cat();
            Human human=new Human();
            human.run(cat);
            human.run(dog);
        }
    }
