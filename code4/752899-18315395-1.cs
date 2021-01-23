    class Animal
    {
       // Factory method
       public static Animal Create(string name)
       {
          Animal animal = null;
          ...  // some logic based on 'name'
              animal = new Zebra();
          return animal;
       }
    }
     
