    public struct Guess
    {
        public List<int> Digits { get; set; }
    }
    public class GuessingGame
    {
        List<Guess> guesses;
        public GuessingGame()
        {
            guesses=new List<Guess>();
        }
        public void Guess(List<int> digits)
        {
            guesses.Add(new Guess() { Digits=digits });
        }
    }
