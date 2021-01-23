    private void submitButton_Click(object sender, EventArgs e)
    {
        var userAnswer = double.Parse(txtResult.Text);
    
        if (!Question.CheckIfRight(userAnswer))
        {
            MessageBox.Show("Wrong");
            return;
        }
        MessageBox.Show("Right!!");
        RefreshQuestion();
    }
