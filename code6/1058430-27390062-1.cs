    public class RPSMatch
    {
        private static readonly Random random = new Random();
        public Result MatchResult { get; private set; }
        public Choice ComputerChoice { get; private set; }
        public Choice PlayerChoice { get; private set; }
        public enum Choice
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3,
        }
        public enum Result
        {
            Lose = -1,
            Draw = 0,
            Win = 1,
        }
        public RPSMatch(Choice playerChoice)
        {
            var computerChoice = (Choice)random.Next(1, 4);
            this.PlayerChoice = playerChoice;
            this.ComputerChoice = computerChoice;
            var diff = (int)playerChoice - (int)ComputerChoice;
            this.MatchResult = (Result)(Math.Sign(diff) * (Math.Abs(diff) == 2 ? -1 : 1));
        }
    }
