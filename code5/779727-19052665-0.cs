    void AddNewAnimal<T>(List<T> animals, string className)
    {
        Type animalType = Type.GetType(className); // eg lion, tiger
        object newAnimal = Activator.CreateInstance(animalType);
        animals.Add((T)Convert.ChangeType(newAnimal, typeof(T)));
    }
