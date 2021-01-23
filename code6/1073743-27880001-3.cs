    private void NextButton_Click(object sender, EventArgs e)
    {
    	if (QuestionList.Count == 0)
    	{
    		MessageBox.Show("No more questions.");
    	}
    	else
    	{
    		// Get next question.
    		GetQuestion();
    		AssignValues();
    		GetAnswer();
    	}
    } 
