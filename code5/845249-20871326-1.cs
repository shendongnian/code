    exam.Text = db.Questions.FirstOrDefault(t => t.ID == 1);
    exam.Foil1 = db.Answers.FirstOrDefault(t => t.ID == 1);
    exam.Foil2 = db.Answers.FirstOrDefault(t => t.ID == 1);
    exam.Foil3 = db.Answers.FirstOrDefault(t => t.ID == 1);
    exam.CorrectAnswer = db.Answers.FirstOrDefault(t => t.ID == 1);
