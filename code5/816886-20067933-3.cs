    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 150; i++)
            {
                CreateImage();
            }
            GC.Collect();
            //Something to do while the GC runs
            FindPrimeNumber(1000000);
            foreach (var zombie in Zombie.Undead)
            {
                //object is still accessable, image isn't
                zombie.Image.Save(@"C:\temp\x.png");
            }
            Console.ReadLine();
        }
        //Borrowed from here
        //http://stackoverflow.com/a/13001749/969613
        public static long FindPrimeNumber(int n)
        {
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;// to check if found a prime
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                    count++;
                a++;
            }
            return (--a);
        }
        private static void CreateImage()
        {
            var zombie = new Zombie(new Bitmap(@"C:\temp\a.png"));
            zombie.Image.Save(@"C:\temp\b.png");
        }
    }
    internal class Zombie
    {
        public static readonly List<Zombie> Undead = new List<Zombie>();
        public Zombie(Image image)
        {
            Image = image;
        }
        public Image Image { get; private set; }
        ~Zombie()
        {
            Undead.Add(this);
        }
    }
