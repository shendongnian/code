    int count = 0;
    private void AnalyzeQuestion(int x)
    {
        if (txtanswer.Text == entertainmentanswers[x])
        {
            MessageBox.Show("You got this one right!", "Correct!");
            correct += 1;
        }
        else
        {
            MessageBox.Show("You got this one wrong! The correct answer was " + entertainmentanswers[x], "Wrong!");
            incorrect += 1;
        }
    }
    private void btnanswer_Click(object sender, EventArgs e)
    {
        //button pressed to submit answer
        AnalyzeQuestion(count);
        count++;
        KeepScore();
        ResetPrompt();
        lblquestion.Text = entertainmentquestions[count];
    }
