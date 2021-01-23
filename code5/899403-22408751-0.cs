    private void NextQuestion_Click(object sender, EventArgs e)
    {
    	if (QuestionsBindingSource != null)
    	{
    		QuestionsBindingSource.MoveNext();
    		if (QuestionsBindingSource.Current != null)
    		{
    			DataRow row = (DataRow)QuestionBindingSource.Current;
    			yourTextBox.Text = row["FieldYouWant"].ToString();
    		}
    	}	
    }
