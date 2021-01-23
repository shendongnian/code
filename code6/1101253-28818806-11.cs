    internal class Question
    {
        public const int MinDifficulty = 1;
        public const int MaxDifficulty = 10;
        private int _difficulty;
        public int Difficulty
        {
            get { return _difficulty; }
            set
            {
                if (value < MinDifficulty) _difficulty = MinDifficulty;
                else if (value > MaxDifficulty) _difficulty = MaxDifficulty;
                else _difficulty = value;
            }
        }
        public string QuestionString { get; set; }
    }
