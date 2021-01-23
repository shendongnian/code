    QuizEntities quiz = new QuizEntities();
    Question question = new Question();
    Answer answer = new Answer();
    
    question.Title = titleBox.Text;
    question.ImageURL = "../Uploads/" + PhotoBox.Text;
     quiz.Questions.Add(question);
    
    //Add first answer.
     answer.Answer = firstAnswer.Text;
     if (firstCheckBox.Checked)
     {
       answer.IsCorrect = true;
     }
     else
     {
       answer.IsCorrect = false;
     }
    
     answer.questionId = question.Id;
     quiz.Answers.Add(answer);
    //Add second answer.
    answer = new Answer();
     answer.Answer = secondAnswer.Text;
     if (secondCheckBox.Checked)
     {
       answer.IsCorrect = true;
     }
     else
     {
       answer.IsCorrect = false;
     }
    
     answer.questionId = question.Id;
     quiz.Answers.Add(answer);
     
    //... add third and fourth as well.
     quiz.SaveChanges();
