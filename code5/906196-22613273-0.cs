    public class Animal {
      public int NbOfEyes {get;set;}
    }
    
    public class Dog : Animal {
      public bool IsPolite {get;set;}
    }
    
    Animal dog = new Dog();
    dog.IsPolite = false; //you can't do that. dog is an animal, it doesn't know it can be polite.
    dog.NbOfEyes = 2;//you can do that, you have access to animal's properties /methods
    
    Dog dog2 = new Dog();
    dog2.IsPolite = false; // you can do that.
    dog2.NbOfEyes = 4; //you can also do that, you have access to base class's properties / methods.
