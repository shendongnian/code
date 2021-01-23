    public enum Difficulty { Easy, Normal, Hard }
    public class Foo
    {
        private Difficulty difficulty;
        public void SetDifficulty(Difficulty value)
        {
            difficulty = value;
        }
        public Difficulty GetDifficulty()
        {
            return difficulty;
        }
    }
