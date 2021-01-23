    public class GuessingGame
    {
        Random random;
        public GuessingGame()
        {
            random = new Random();
            this.Guesses = new List<Guess>();
            this.Target = new List<int>() { 1, 2, 3 };
        }
        ...
