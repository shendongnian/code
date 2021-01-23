    public int AttackPower {
            get { return this.power; }
        }
    
    protected abstract int Power { get; }
    
    public class Lancer:Soldier {
    
        protected override int Power { get { return 5; } }
    }
