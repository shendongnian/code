    public abstract class Damage : MonoBehaviour 
    {
        public int health = 100;
    
        public virtual void ReceiveDamage(int damageAmount)
        {
           Debug.Log ("Original");
        }
    }
