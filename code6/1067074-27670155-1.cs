    public abstract class Animal
    {
        public string Name { get; set; }
    
        public abstract void Cure();
    }
    public class AnimalClinic
    {
        public void CureAnimal(Animal animal)
        {
            animal.Cure();
        }
    }
    public class Dog : Animal
    {
        public override void Cure()
        {
            Console.WriteLine("We heal fine dogs!");
        }
    }
