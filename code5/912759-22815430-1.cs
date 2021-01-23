    public partial class Presenter {
        public Presenter() {
            // add some dummy questions, removed to make it less messy
        }
        private List<Question> questions = new List<Question>();
        public Question GetQuestion(int questionNumber) {
            return questions[questionNumber];
        }
    }
