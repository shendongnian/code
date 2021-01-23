    public class PlayerDamage : Damage 
    {
        public override void ReceiveDamage(int damageAmount)
        {
           Debug.Log("Extended");
        }
    }
