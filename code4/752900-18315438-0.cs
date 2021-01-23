    var x = Animal.ForName("Rex");
    var x = Animal.ForName("Mittens");
    ...
    public abstract class Animal
    {
        public static Animal ForName(string name)
        {
            if (dogNames.Contains(name))
            {
                return new Dog(name);
            }
            else
            {
                return new Cat(name);
            }
        }
    }
