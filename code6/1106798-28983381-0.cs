    public abstract class CharacterBase
    {
        public virtual int Level { get; set; }
    }
    public class ConcreteCharacter : CharacterBase
    {
        public override int Level
        {
            get
            {
                return 1; //or whatever
            }
            set
            {
                // your implementation
            }
        }
    }
