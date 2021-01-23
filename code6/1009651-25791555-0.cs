    public abstract class Animal
    {
        public string Type { get; private set; }
        public string Name { get; set; }
        protected Animal(string type)
        {
            Type = type;
        }
        public virtual string Examine()
        {
            return string.Format("This is a {0}. Its name is {1}.", Type, Name);
        }
    }
    public class Dog : Animal
    {
        public Dog() : base("Dog")
        {
        }
    }
    public class Cat : Animal
    {
        public Cat() : base("Cat")
        {
        }
    }
    var dog = new Dog { Name = "Rex" };
    var cat = new Cat { Name = "Phil Collins" };
