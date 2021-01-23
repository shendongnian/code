        class Monkey : Beast
        {
            public void MonekeyBehavior()
            {
                ....
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Monkey Monkey = new Monkey();
                Beast Pig = new Beast();
                Beast Rino = new Beast();
                Monkey.Prowl(); Pig.Prowl(); Rino.Prowl();
                Console.ReadKey();
            }
        }
