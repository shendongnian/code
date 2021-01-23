    // This interface doesn't really define what a class is, only
    // that it can, in fact, have Cheeseburgers.
    public interface ICanHasCheeseburgers
    {
         List<Cheeseburger> Cheeseburgers { get; }
    }
    // This abstract class, defines what a derived class 'is'.
    // If you are familiar with biology, imagine: kingdom, phylum, class, order, 
    // genius, species.  It's different levels of abstraction for a 'thing'.
    public abstract class Animal
    {
    }
    // The cat class derives from the Animal class just as a Dog class might.
    // This is a Is-A relationship; the Cat is an Animal.  It also implements 
    // the ICanHasCheeseburgers interface which represents a Can-Do relationship.
    public class Cat : Animal, ICanHasCheeseburgers
    {
         // this property represents a Has-A relationship between our Cat
         // class and a Cheeseburger class.  The cat can have any number of
         // Cheeseburger objects.
         public List<Cheeseburger> Cheeseburgers { get; private set; }
         public Cat(RandomNumberGenerator generator) 
         {
              if (generator != null) 
              {
                  var number = generator.GetRandom();
                  var burgers = new List<Cheeseburger>();
                  while(number > 0) {
                      burgers.add(new Cheeseburger());
                      number--;
                  }
                  Cheeseburgers = burgers;
              }
         }
    }
