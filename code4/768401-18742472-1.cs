    private List<Questions> questions = new List<Questions>()
        {
            new Questions()
            {
                 Question = "welcome to question 1",
                 CorrectAnswer = 2,
            },
            new Questions()
            {
                 Question = "welcome to question 2",
                 CorrectAnswer = 1,
            },
            new Questions()
            {
                Question =  "welcome to question 3",
                CorrectAnswer = 3,
            },
            new Questions()
            {
                Question = "welcome to question 4",
                CorrectAnswer = 2,
            },
            
        };
        int currentQuestionIndex = 0;
        private int numberCorectAnswer = 0;
        public List<RadioButton> listRadioButton = null;
        
        public void Click_AppBar(object sender, System.EventArgs e)
        {
            if (listRadioButton == null)
            {
                listRadioButton = new List<RadioButton>()
                {
                    RadioA,
                    RadioB,
                    RadioC,
                };
            }
            Questions previousQuestions = this.questions[currentQuestionIndex];
            if (listRadioButton[previousQuestions.CorrectAnswer].IsChecked == true)
            {
                
                numberCorectAnswer++;
            }
            if (currentQuestionIndex == questions.Count-1)
            {
                MessageBox.Show("You have finished, number correct answer:" +numberCorectAnswer);
            }
            currentQuestionIndex++;
            textBlock1.Text = this.questions[currentQuestionIndex];
            //ShowResult.Text = (a.ToString());
        }
