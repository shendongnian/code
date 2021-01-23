    public class Farm<TAnimal> where TAnimal : Animal
    {
        public TAnimal myAnimal;
    }
    public class SheepFarm : Farm<Sheep>
    {
        public void SheepFarm()
        {
            this.myAnimal = new Sheep();
            this.myAnimal.makeALamb();
        }
    }
