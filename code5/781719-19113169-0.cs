    public class Animal
    {
        public int ID {get; set;}
        public string Name {get; set;}
        ...
    }
    ObservableCollection<Animal> animals = ...
    animals.OrderByDescending(a => a.Name);
