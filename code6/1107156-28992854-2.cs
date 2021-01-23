    void Main()
    {
        ILivingThing<Appendage> mysteryAnimal = new Cat();
    }
    
    public class Appendage { }
    public class Paw : Appendage { }
    
    public interface ILivingThing<out TExtremity> where TExtremity : Appendage { }
    // You have a choice of keeping Animal a class. If you do, the assignment
    // Animal<Appendage> mysteryAnimal = new Cat()
    // would be prohibited.
    public interface IAnimal<TExtremity> : ILivingThing<out TExtremity> where TExtremity : Appendage { }
    public class Cat : Animal<Paw> { }
