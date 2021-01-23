    public DogDetails GetDogDetails (int id)
    {
        DogDetails dog = new DogDetails();
        QueryFromDatabase(dog, id);
        return dog;
    }
    public CatDetails GetCatDetails (int id)
    {
        CatDetails cat = new CatDetails();
        QueryFromDatabase(cat, id);
        return cat;
    }
    private void QueryFromDatabase (AnimalDetails animal, int id)
    {
        // fetch from database, and fill the animal object with the values
        var databaseData = FetchObject(id);
        animal.Name = databaseData.GetString("name");
        animal.Height = databaseData.GetFloat("height");
        animal.Weight = databaseData.GetFloat("weight");
    }
