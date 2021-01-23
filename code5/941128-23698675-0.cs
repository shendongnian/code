    public abstract class Animal 
    {
        public abstract void makeChild();
    }
    public class Sheep : Animal
    {
        public override void makeChild() 
        {
            Console.WriteLine("A lamb is born.");
        }
    }
    public class Cow : Animal
    {
        public override void makeChild()
        {
            Console.WriteLine("A calf is born.");
        }
    }
    public class Farm
    {
        public Animal myAnimal;
    }
    public class SheepFarm : Farm
    {
        public SheepFarm()
        {
            this.myAnimal = new Sheep();
            this.myAnimal.makeChild();
        }
    }
    public class CowFarm : Farm
    {
        public CowFarm()
        {
            this.myAnimal = new Cow();
            this.myAnimal.makeChild();
        }
    }
