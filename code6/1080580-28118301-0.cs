    private TaskCompletionSource<bool> _completionSource;
    private async void button1_Click(object sender, EventArgs e)
    {
        int[] questionIndexes = ShuffleQuestions();
        for (int iAsked = 0; iAsked < 5; iAsked++)
        {
            textBoxQuestionNumber.Text = string.Format("Question {0}", iAsked);
            textBoxQuestion.Text = astrQuestions[questionIndexes[iAsked]];
            textBoxChoices.Text = astrChoices[questionIndexes[iAsked]];
            _completionSource =
                new TaskCompletionSource<bool>(astrAnswers[questionIndexes[iAsked]]);
            button2.Enabled = true;
            bool result = await _completionSource.Task;
            MessageBox.Show(result ? "Correct" : "Incorrect");
            if (result)
            {
                iPoints += 5;
                iCorrect++;
            }
            button2.Enabled = false;
            _completionSource = null;
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        if (_completionSource != null)
        {
            _completionSource.SetResult(
                textBoxUserAnswer.Text == (string)_completionsSource.Task.AsyncState);
        }
    }
