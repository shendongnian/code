    public interface IAnimal
    {
    }
    public class Dog : IAnimal
    {
    }
    public class Cat : IAnimal
    {
    }
    public abstract class AnimalGroomer<T> where T:IAnimal
    {
        public Type AnimalType { get { return typeof(T); } }
        public abstract void Groom(T animal);
    }
    public class CatGroomer : AnimalGroomer<Cat>
    {
        public override void Groom(Cat animal)
        {
            Console.WriteLine("{0} groomed by {1}", animal.GetType(), this.GetType());
        }
    }
    public class DogGroomer : AnimalGroomer<Dog>
    {
        public override void Groom(Dog animal)
        {
            Console.WriteLine("{0} groomed by {1}", animal.GetType(), this.GetType());
        }
    }
    public class AnimalClinic
    {
        private Dictionary<Type, dynamic> groomers = new Dictionary<Type, dynamic>();
        public void EmployGroomer<T>(AnimalGroomer<T> groomer) where T:IAnimal
        {
            groomers.Add(groomer.AnimalType, groomer);
        }
        public void Groom(IAnimal animal)
        {
            var groomer = groomers[animal.GetType()];
            groomer.Groom((dynamic)animal);
        }
    }
