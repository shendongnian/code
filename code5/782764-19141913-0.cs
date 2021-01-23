    class Dog
    {
       string Name
       public void Bark()
       {
         Console.WriteLine("{0} just barked!", Name)
       }
       public Dog(string name)
       {
         this.Name=name;
       }
    }
    
    static void Main()
    {
      Dog Spike=new Dog("Spike");
      Dog Mike=new Dog("Mike");
      Spike.Bark();
    }
