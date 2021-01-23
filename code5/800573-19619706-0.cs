    void Main()
    {
    
        var myAnimals = new List<Animal>() { new Animal() { Name = "Zebra" },
                                             new Animal() { Name = "Cobra" }} ;
    
        var myPeople = new List<Person>() { new Person() { Name = "Snake Pliskin" },
                                            new Person()  { Name = "OmegaMan" }};
    
    
        // Uses System.Windows.Data
        var FavoriteThings = new CompositeCollection();
    
        FavoriteThings.Add(myAnimals);
        FavoriteThings.Add(myPeople);
    
    
    }
    
    // Define other methods and classes here
    public class Animal
    {
        public string Name { get; set; }
    }
    
    
    public class Person
    {
        public string Name { get; set; }
    }
