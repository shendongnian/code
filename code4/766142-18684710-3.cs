    List<Animal> animals = new List<Animal>();
    animals.Add(new Jaguar());
    animals.Add(new Owl());
    animals.ForEach(animal =>
    {
        if (animal.HasCapability(AnimalCapability.Fly))
        {
            MessageBox.Show(animal.Name + " can fly");
        }
        else
        {
            MessageBox.Show(animal.Name + " can't fly");
        }
    });
