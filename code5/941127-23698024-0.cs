     public class Animal { }
        public class Sheep : Animal {
            public void makeALamb() { }
        }
    public class Goat: Animal {
            public void makeAGoat() { }
        }
        public class Farm
        {
            public Goat myGoat;
            public Sheep mySheep;
        }
        public class MyFarm : Farm {
            public void MyFarm() {
                this.mySheep= new Animal();
                this.mySheep.makeALamb();
            }
        }
