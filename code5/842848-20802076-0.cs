    public class GuessingGame
    {
        private Random _random;
        public GuessingGame()
        {
            this.Guesses = new List<Guess>();
            this.Target = new List<int>() { 1, 2, 3 };
            this._random = new Random();
        }
        public List<int> Target { get; set; }
        public List<Guess> Guesses { get; set; }
       ...
        public void NewGame()
        {
            this.Target.Clear();
            var count = 4;
            for (var i = 1; i < count; i++)
            {
                var swap = _random.Next(1, 9);
                if (!this.Target.Contains(swap))
                {
                    this.Target.Add(swap);
                }
            }
        }
