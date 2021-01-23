    public abstract class Soldier {
        public int Power {get; set;}
    
        public int AttackPower {
            get { return this.Power; }
        }
    
        public Attack {
            Console.WriteLine("Attacked with "+AttackPower+" attack power");
        }
    }
    
    public class Lancer:Soldier {
        public Lancer()
        {
            Power = 5
        }
    }
    
    public class Archer:Soldier {
        public Archer()
        {
             Power=10;
        }
    }
