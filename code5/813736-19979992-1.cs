    public class Animal
    {
        public virtual void Sleep()
        {
            Console.WriteLine(@"I'm an animal, and I want to sleep.
            I just close my eyes");
        }
    }
    public class Mammal : Animal
    {
        public override void Sleep()
        {
            Console.WriteLine(@"I'm a mammal, thus basically an animal.
            Therefore, I both close my eyes, and need a warm place to sleep");
        }
        public bool HasBreasts
        {
            get
            {
                return true;
            }
        }
    }
    public class Human : Mammal
    {
        public new virtual void Sleep()
        {
            Console.WriteLine(@"I'm a human. 
            I'm so proud that I don't consider myself as an animal. 
            I sleep in a cozy place, 
            and I need a lot of money to sleep well");
        }
        public virtual void FallInLove();
    }
    public class Worker : Human
    {
        public override void Sleep()
        {
            Console.WriteLine(@"I'm a worker, and I'm under poverty line. 
            I have to work hard, 
            and I really don't know what they mean by a good sleep");
        }
        public override void FallInLove()
        {
            Console.WriteLine(@"What is love? 
            I need bread to survive. 
            I'm in the bottom-most level of Mozlow's pyramid of needs.");
        }
    }
