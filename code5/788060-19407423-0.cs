        public interface IAnimal
        {
            string GroomSound { get; }
        }
    
        public class Dog : IAnimal
        {
            public string GroomSound
            {
                get{ return "Woof";}
            }
    
            public string AngrySound
            {
                get{ return "Rooof!";}
            }
        }
    
        public class Cat : IAnimal
        {
            public string GroomSound
            {
                get { return "Purrr";}
            }
        }
    
        public interface IGroomer
        {
            void Groom(IAnimal animal);
        }
    
        public class Groomer<T> : IGroomer where T : class, IAnimal
        {
            public virtual void Groom(IAnimal animal)
            {
                Console.WriteLine(animal.GroomSound);
            }
        }
    
        public class DogGroomer : Groomer<Dog>
        {
            public override void Groom(IAnimal animal)
            {
                Console.WriteLine(((Dog)animal).AngrySound);
            }
        }
    
        public class CatGroomer : Groomer<Cat>
        {       
        }
    
        public class AnimalClinic
        {
            Dictionary<Type, IGroomer> _groomers = new Dictionary<Type, IGroomer>();
    
            public void AddGroomer<T>(Groomer<T> groomer) where T : class, IAnimal
            {
                _groomers.Add(typeof(T), groomer);
            }
    
            public void Groom(IAnimal animal)
            {
                IGroomer groomer;
                _groomers.TryGetValue(animal.GetType(), out groomer);
    
                if (groomer != null)
                    groomer.Groom(animal);
                else
                    Console.WriteLine("Groomer not available for your {0}", animal.GetType());
            }
        }
    
    ...
        var clinic = new AnimalClinic();
    
        clinic.AddGroomer(new DogGroomer());
        clinic.AddGroomer(new CatGroomer());
    
        clinic.Groom(new Cat());
        clinic.Groom(new Dog());
    
    \\Output:
    \\Purrr
    \\Rooof!
    
    
    ...
