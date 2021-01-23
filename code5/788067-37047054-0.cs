    public class AnimalGroomerClinic {
        public Dictionary<string, object> animalGroomers = new Dictionary<string, object>();
    
        public void employGroomer<T>(IAnimalGroomer<T> groomer) where T : IAnimal {
            animalGroomers.Add(groomer.getAnimalType(), groomer);
        }
        public void Groom<T>(T animal) where T : IAnimal {
            // Could also check here if the 'as' operator returned null,
            // which might happen if you don't have the specific groomer
            (animalGroomers[animal.getAnimalType()] as IAnimalGroomer<T>).groom(animal);
        }
    }
