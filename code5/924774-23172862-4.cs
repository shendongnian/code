    class Program
    {
        static void Main(string[] args)
        {
            Animal a = new Animal();
            Cat c = new Cat();
            Animal ac = new Cat();
            a.Noise(a);
            a.Noise(c);
            a.Noise(ac);
            c.Noise(a);
            c.Noise(c);
            c.Noise(ac);
            a.Poop();
            c.Poop();
            ac.Poop();
            Console.Read();
        }
    }
    public class Animal
    {
        public void Noise(Animal a)
        {
            Console.WriteLine("Animal making noise!");
        }
        public void Poop()
        {
            Console.WriteLine("Animal pooping!");
        }
    }
    public class Cat : Animal
    {
        public void Noise(Cat c)
        {
            Console.WriteLine("Cat making noise!");
        }
        public void Noise(Animal c)
        {
            Console.WriteLine("Animal making noise!");
        }
        public void Poop()
        {
            Console.WriteLine("Cat pooping in your shoe!");
        }
    }
