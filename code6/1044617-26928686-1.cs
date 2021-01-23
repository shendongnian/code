    public void QueryAnimalProperties(out IAnimal animal_details)
    {
       animal_details = new Hamster();
    }
//
    Dog dog;
    QueryAnimalProperties(out dog);
