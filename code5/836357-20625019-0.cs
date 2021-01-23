    interface IAnimal()
    {
      public void HaveLunch();
    }
    
    class Zebra:IAnimal
    class Lion:IAnimal
    
    
    interface IZoo
    {
      List<IAnimal> Zebras {get;set;}
      List<IAnimal> Lions {get;set;}
    }
    
    public class Zoo
      : IZoo //does not work
    {
      List<Zebra> Zebras {get;set;}
      List<Lion> Lions {get;set;}
    }
    
    
    //...
    IZoo myZoo = new Zoo;
    myZoo.Zebras.Add(new Lion());  //because of this.
