    public abstract class CharacterBase
    {
        public abstract int Level { get; set; }
    }
    public class Character : CharacterBase
    {
        private int level = 1;
        public override int Level
        {
            get { return level; }
            set 
            {
                level = value;
                Console.WriteLine("The new level is {0}.", level);
            }
        }
    }
