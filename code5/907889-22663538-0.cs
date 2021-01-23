    private void buttonNext_Click(object sender, EventArgs e)
    {
      if (_questionNumber < _xmlHandler.Questions.Count - 1)
        DisplayQuestion(++_questionNumber);
    }
    
    private void buttonBack_Click(object sender, EventArgs e)
    {
      if (_questionNumber > 0)
        DisplayQuestion(--_questionNumber);
    }
