     public partial class Page1 : PhoneApplicationPage
    {
        private List<Question> questionList;
        private int currentQuestionIndex = 0;
        private Question currentQuestion;
        private int Score = 0;
        public Page1()
        {
            InitializeComponent();
            questionList = new List<Question>();
            questionList.Add(new Question { Text = "This is the first question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 1 });
            questionList.Add(new Question { Text = "This is the second question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 2 });
            questionList.Add(new Question { Text = "This is the third question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 1 });
            questionList.Add(new Question { Text = "This is the forth question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 2 });
            questionList.Add(new Question { Text = "This is the fifth question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 1 });
            questionList.Add(new Question { Text = "This is the sixth question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 2 });
            questionList.Add(new Question { Text = "This is the seventh question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 1 });
            questionList.Add(new Question { Text = "This is the eitht question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 2 });
            questionList.Add(new Question { Text = "This is the ninth question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 1 });
            questionList.Add(new Question { Text = "This is the tenth question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 2 });
            questionList.Add(new Question { Text = "This is the first question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 1 });
            questionList.Add(new Question { Text = "This is the second question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 2 });
            questionList.Add(new Question { Text = "This is the third question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 1 });
            questionList.Add(new Question { Text = "This is the forth question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 2 });
            questionList.Add(new Question { Text = "This is the fifth question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 1 });
            questionList.Add(new Question { Text = "This is the sixth question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 2 });
            questionList.Add(new Question { Text = "This is the seventh question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 1 });
            questionList.Add(new Question { Text = "This is the eitht question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 2 });
            questionList.Add(new Question { Text = "This is the ninth question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 1 });
            questionList.Add(new Question { Text = "This is the tenth question", Answers = new List<string> { "A", "B", "C", "D" }, CorrectAnswer = 2 });
            tempList = new List<Question>(questionList);
            Random rand = new Random();
            //assign currentQuestionIndex new random number
            currentQuestionIndex = rand.Next(0, tempList.Count);
            loadquestion(currentQuestionIndex);
        }
        private void loadquestion(int questionindex)
        {
            currentQuestion = tempList[questionindex];
        }
        private List<Question> tempList;
        private int questionNumber = 0;
        private void Next_Click(object sender, System.EventArgs e)
        {
            //if(CorrectAnswer)
            Score++;
            questionNumber++;
            if (currentQuestionIndex < tempList.Count)
            {
                //delete previous item from tempList
                tempList.RemoveAt(currentQuestionIndex);
            }
            //if no more questions, then Display completed and disable Next Button
            if (tempList.Count == 0)
            {
                MessageBox.Show(String.Format("Your have completed , Your Final score is {0}", Score));
                return;
            }
            Random rand = new Random();
            //assign currentQuestionIndex a new random number
            currentQuestionIndex = rand.Next(0, tempList.Count);
            loadquestion(currentQuestionIndex);
            if (questionNumber % 10 == 0)
            {
                //show level messages each time at 10,20,.......
                MessageBox.Show(String.Format("Your score is {0}", Score));
            }
        }
    }
