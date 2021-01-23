        class Monkey : Beast
        {
            public void MonkeyBehavior()
            {
                ....
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Monkey monkey = new Monkey();
                Pig pig = new Pig();
                Rino rino = new Rino();
                monkey.Prowl(); pig.Prowl(); rino.Prowl();
                Console.ReadKey();
            }
        }
