    public abstract class AnimalToy<TAnimal> where TAnimal : Animal
    {
        public AnimalToy(TAnimal owner)
        {
            Owner = owner;
        }
    
        public TAnimal Owner { get; private set; }    
    }
    public class PlasticBone: AnimalToy<Dog>
    {
        public PlasticBone(Dog owner) : base(owner) {}
    
        public void Throw()
        {
            Owner.Bark();
        }
    }
