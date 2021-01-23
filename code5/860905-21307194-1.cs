    public List<IAnimal> getAnimals()
    {
        return new List<Dog>();
    }
    // You just Dog'd a list of Cats
    IEnumerable<Cat> cats = getAnimals();
