    List<Question> Questions = new List<Question>();
    ...
    ...
    private void GenerateQuestions()
    {
        Questions.Clear();
        Questions.Add(new Question(1, Q1.Text, Q1.Visible, Q1.IsChecked));
        Questions.Add(new Question(2, Q2.Text, Q2.Visible, Q2.IsChecked));
        // and so on
    }
