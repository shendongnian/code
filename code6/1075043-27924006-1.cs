    public class Country
    {
        private Country()
        {
        }
        public int Population {get; private set;}
        // Static members
        
        public static Country USA {get; private set;}
        public static Country Italy {get; private set;}
        static Country()
        {
            USA = new Country { Population = 100000 };
            Italy = new Country { Population = 50000 };
        }
    }
