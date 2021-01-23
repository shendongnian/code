    namespace BanjoStore
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Create a Banjo!
                var myFirstBanjo = new Banjo("it's my first!", 4, 67, Banjo.BanjoState.Used);
                //Oh no! The above line didn't work because I can't access BanjoState!
                //I can't used the enum to pass in the value because it's private to the 
                //Banjo class. THAT is why the error was visible in the constructor. 
                //Visual Studio knew this would happen!
            }
        }
    
        class Banjo
        {
            //These are private by default since there isn't a keyword specified 
            //and they're inside a class:
            string description;
            int price;
    
            //This is also private, with the access typed in front so I don't forget:
            private int banjoID; 
    
            //This enum is private, but it SHOULD be:
            //public enum BanjoState
            //Even better, it can be internal if only used in this assembly
            enum BanjoState
            {
                Used,
                New
            }
    
            public Banjo(string inDescription, int inPrice, int inBanjoID,
                         BanjoState inState)
            {
                description = inDescription;
                price = inPrice;
                banjoID = inBanjoID;
                BanjoState state = inState;
            }
        }
    }
