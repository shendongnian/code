    abstract class Character
    {
        // Something everyone has
        public int HitPoints { get; set; }
        // Something everyone does, but does differently
        public abstract void Attack(Character target);    
    }
    
    public class Fighter : Character
    {
        public int SwordDamage { get; set; }
    
        public void Attack(Character target)
        {
            target.Damage(this.SwordDamage - target.PhysicalDamageResistance);
        }
    }
    
    public class Mage : Character
    {
        public int MagicFireDamage { get; set; }
        public int MagicColdDamage { get; set; }
    
        public void Attack(Character target)
        {
            if (UseFireDamage()) // e.g. roll random chance that the mage uses a fire spell
            {
                target.Damage(this.SwordDamage - target.FireDamageResistance);
            }
            else
            {
                target.Damage(this.SwordDamage - target.ColdDamageResistance);
            }
    
        }
    }
