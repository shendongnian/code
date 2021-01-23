    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication7
    {
      public class Animal
      {
      }
      public class Cow : Animal
      {
      }
      public class Horse : Animal
      {
      }
      public class Sheep : Animal
      {
      }    
      public class Animals
      {        
        protected ArrayList List { get; set; }
        protected Type Type { get; set; }
        public Animals(Type type)
        {
            this.Type = type;
            this.List = new ArrayList();
        }
        public void AddAnimal(Animal animal)
        {
            if (animal.GetType() == this.Type)            
                this.List.Add(animal);            
            else
                throw new Exception("Not expected type");
        }
     }
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new Sheep();
            var s2 = new Sheep();
            var c1 = new Cow();
            var sheepList = new Animals(typeof(Sheep));
            sheepList.AddAnimal(s1);
            sheepList.AddAnimal(s2);
            sheepList.AddAnimal(c1);//throws an exception
        }
      }
    }
