    using (var quiz = new QuizEntities())
    {
        var qId = 1;
        var question = new Question
        {
            Id = qId,
            title = titleBox.Text,
            ImageURL = "../Uploads/" + PhotoBox.Text
        };
    
        quiz.Questions.Add(question);
        quiz.Answers.Add(
            CreateAnswer(1, firstAnswer.Text, (bool)firstCheckBox.Checked, qId));
        quiz.Answers.Add(
            CreateAnswer(2, secondAnswer.Text, (bool)secondCheckBox.Checked, qId));
        quiz.Answers.Add(
            CreateAnswer(3, thirdAnswer.Text, (bool)thirdCheckBox.Checked, qId));
        quiz.Answers.Add(
            CreateAnswer(4, fourthAnswer.Text, (bool)fourthCheckBox.Checked, qId));
        quiz.SaveChanges();
    }
