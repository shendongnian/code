    private void DisplayQuestion(int questionNumber)
    {
        var qNumber = _presenter.GetQuestion(questionNumber);
        if (string.Equals(qNumber.QuestionType, "ComboBoxControl"))
        {
            controlPanel.Controls.Clear();
            var comboBox = new ComboBoxControl(qNumber);
            comboBox.Dock = DockStyle.Fill;
            comboBox.SelectedIndexChanged += SelectedAnswerChanged;
            controlPanel.Controls.Add(comboBox);
        }
    }
