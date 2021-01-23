    public abstract class Animal
    {
        public abstract void Eat();
        ...
    }
    public class Giraffe : Animal
    {
        public override void Eat()
        {
            // Giraffe eating
        }
        ...
    }
    public class Monkey : Animal
    {
        public override void Eat()
        {
            this.PeelBanana();
            this.EatBanana();   //Or something like this
        }
        ...
    }
