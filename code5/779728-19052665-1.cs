      public bool AddNewAnimal(List<Animal> animals, string className)
      {
         bool success = false;
         Type animalType = Type.GetType(className);
         if (typeof(Animal).IsAssignableFrom(animalType))
         {
            object newAnimal = Activator.CreateInstance(animalType);
            animals.Add((Animal)newAnimal);
            success = true;
         }
         return success;
      }
