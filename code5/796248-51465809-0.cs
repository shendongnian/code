    public class RestorableRandom
    {
        public Random Generator { get; private set; }
        public RestorableRandom()
        {
            Generator = new Random();
        }
        public RestorableRandom(int seed)
        {
            Generator = new Random(seed);
        }
        public int GetState()
        {
            int state = Generator.Next();
            Generator = new Random(state);
            return state;
        }
        public void RestoreState(int state)
        {
            Generator = new Random(state);
        }
    }
