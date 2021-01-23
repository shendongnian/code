    public partial class SurveyView : Form {
        private readonly Presenter presenter;
        private int currentQuestion = 0;
        public SurveyView() {
            InitializeComponent();
            presenter = new Presenter();
            
            // currentQuestion initially set to 0, will load first question
            // will increment it/decrement it by 1 based on button click
            loadQuestion(currentQuestion);
        }
        private void loadQuestion(int questionNumber) {
            // clear out the text and answers displayed (if any)
            lblQuestion.Text = string.Empty;
            cbxAnswers.Text = string.Empty;
            cbxAnswers.Items.Clear();
            // get the question we want
            Question question = presenter.GetQuestion(questionNumber);
            // display the QuestionText
            lblQuestion.Text = question.QuestionText;
            // load each answer into the combo box
            foreach (Answer answer in question.Answers) {
                cbxAnswers.Items.Add(answer);
            }
            if (question.SelectedAnswer != null) {
                cbxAnswers.SelectedItem = question.SelectedAnswer;
            }
        }
        private void PreviousButtonClicked(object sender, EventArgs e) {
            currentQuestion--;
            loadQuestion(currentQuestion);
        }
        private void NextButtonClicked(object sender, EventArgs e) {
            currentQuestion++;
            loadQuestion(currentQuestion);
        }
        // Tied to SelectedIndexChanged event on combo box
        private void SelectedAnswerChanged(object sender, EventArgs e) {
            Question question = presenter.GetQuestion(currentQuestion);
            question.SelectedAnswer = (Answer)cbxAnswers.SelectedItem;
        }
    }
