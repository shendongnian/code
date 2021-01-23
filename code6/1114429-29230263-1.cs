    private MathPuzzle puzzle = new MathPuzzle();
            private void QustionButton_Click(object sender, EventArgs e)
            {
                puzzle.PrepareQuestion();
                QuestionLabel.Text = puzzle.Question;
            }
    
            private void CheckAnswerButton_Click(object sender, EventArgs e)
            {
                double userAnswer = double.Parse(AnswerTextBox.Text);
                if (puzzle.CheckTheAnswer(userAnswer))
                    MessageBox.Show("Correct");
                else
                    MessageBox.Show("Wrong");
            }
