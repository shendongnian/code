    interface IShuffable
    {
        void Shuffle();
    }
    public class QuestionTypeA : Question, IRetryable, IShuffable
    {
        public QuestionTypeA()
        {
            Retries = 1;
        }
        public int Retries { set; get; }
        public void Shuffle()
        {
            // Code to implement shuffling the choices
        }
    }
