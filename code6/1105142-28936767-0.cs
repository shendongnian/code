         static void Main(string[] args)
         {
           Program p = new Program();
           p.display(Mammals(), Carnivore());
         }
         public ZooMammals[] Mammals()
         {
          ZooMammals[] category = new ZooMammals[4];
          category[1] = new ZooMammals() {Category="Carnivorous", Attribute = new Attributes[2] };
          category[2] = new ZooMammals() { Category = "Carnivorous", Attribute= new Attributes[1] };
          category[3] = new ZooMammals() { Category = "Carnivorous", Attribute = new Attributes[3] };
         return category; 
         }
         public Attributes[] Carnivore()
         {
           Attributes[] Carn = new Attributes[3];
           Carn[0] = new Attributes() { Sex ="M", colour = "yellow",Name="Lion" };
           Carn[1] = new Attributes() { Sex ="F", colour = "yellow",Name="Cat"};
           Carn[2] = new Attributes() { Sex ="M", colour = "yellow",Name="Tiger"};
          return Carn;
         }
