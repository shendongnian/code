    public class BowlingScore : IComparable<BowlingScore>
    {
        private int _score = 0;
        public string Name { get; set; }
        public bool IsPerfectGame { get; protected set; }
        public int Score
        {
            get { return this._score; }
            set 
            { 
                    this._score = value; 
                    this.IsPerfectGame = value == 300; 
            }
        }
        public override string ToString()
        {
            if (this.IsPerfectGame)
            {
                return string.Format("{0}'s score was {1}*", this.Name, this.Score);
            }
            else
            {
                return string.Format("{0}'s score was {1}", this.Name, this.Score);
            }
        }
        public int CompareTo(BowlingScore other)
        {
            return this.Score.CompareTo(other.Score);
        }
    }
