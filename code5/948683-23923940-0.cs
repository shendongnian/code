    public interface IDamage
    {
        public int MinDmg { get; get; }
    }
    public class Weapon : Item, IDamage
    {
        //Stuff in here to calculate damage perhaps
    }
    public class Spell : IDamage
    {
        //Spells can also cause damage
    }
