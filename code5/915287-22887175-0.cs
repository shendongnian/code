    public class Monster
    {
        public Monster()
        {
            this.Score = 1;
        }
        public int Score
        {
            get;
            set;
        }
    }
    public class Skeleton : Monster
    {
        public Skeleton()
            : base()
        {
            this.Score = 2;
        }
    }
