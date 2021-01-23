    public interface IBarking{
       public void Barks();
    }
    
    public class Dog : IBarking{
      //some specific dog properties
      public void Barks(){
        string sound = "Bark";
      }
    }
    
    
    public class Wolf : IBarking{
      //some specific wolf properties
      public void Barks(){
        string sound = "Woof";
      }
    }
    
    //and your implementation here:
    
    IBarking barkingAnimal;
    if (isDog){
      barkingAnimal = new Dog();
    }
    else {
      barkingAnimal = new Wolf();
    }
    barkingAnimal.Barks();
