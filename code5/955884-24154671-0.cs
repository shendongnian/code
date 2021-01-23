    class MainApp
    {
    
        public static void Main()
        {
     
            // Abstract factory #1
            AbstractFactory factory1 = new EuropeVehicleFactory();
            Client client1 = new Client(factory1);
            client1.Run();
 
            // Abstract factory #2
            AbstractFactory factory2 = new UsaVehicleFactory();
            Client client2 = new Client(factory2);
            client2.Run();
 
        }
    }
 
    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>
    abstract class AbstractFactory
    {
      public abstract TwoWheelerProduct CreateTwoWheelerProduct();
      public abstract FourWheelerProduct CreateFourWheelerProduct();
    }
 
 
    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    class UsaVehicleFactory : AbstractFactory
    {
      public override TwoWheelerProduct CreateTwoWheelerProduct()
      {
        return new Bike();
      }
      public override FourWheelerProduct CreateFourWheelerProduct()
      {
        return new Car();
      }
    }
 
    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    class EuropeVehicleFactory : AbstractFactory
    {
      public override TwoWheelerProduct CreateTwoWheelerProduct()
      {
        return new Scooter();
      }
      public override FourWheelerProduct CreateFourWheelerProduct()
      {
        return new Jeep();
      }
    }
 
    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>
    abstract class TwoWheelerProduct
    {
    }
 
    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>
    abstract class FourWheelerProduct
    {
      //Disclaimer: I am a temporary citizen...
      public abstract void RunOver(TwoWheelerProduct twoWheeler);
    }
 
 
    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    class Scooter : TwoWheelerProduct
    {
    }
 
    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class Car : FourWheelerProduct
    {
      public override void RunOver(TwoWheelerProduct twoWheeler)
      {
        Console.WriteLine(this.GetType().Name +
          " smashes into " + a.GetType().Name);
      }
    }
 
    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    class Bike : TwoWheelerProduct
    {
    }
 
    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    class Jeep : FourWheelerProduct
    {
      public override void RunsOver(TwoWheelerProduct twoWheeler)
      {
        Console.WriteLine(this.GetType().Name +
          " collides with " + a.GetType().Name);
      }
    }
 
    /// <summary>
    /// The 'Client' class. Interaction environment for the products.
    /// </summary>
    class Client
    {
      private TwoWheelerProduct _abstractTwoWheeler;
      private FourWheelerProduct _abstractFourWheeler;
 
      // Constructor
      public Client(AbstractFactory factory)
      {
        _abstractTwoWheeler = factory.CreateTwoWheeler();
        _abstractFourWheeler = factory.CreateFourWheeler();
      }
 
      public void Run()
      {
        _abstractFourWheeler.RunOver(_abstractTwoWheeler);
      }
    }
