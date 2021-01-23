      for (int i = 0; i < 15; i++)
      {
         long x = Int64.Parse(form[String.Format("Questions[{0}].ObjectId", i)]);
         long y = Int64.Parse(form[String.Format("Questions[{0}].SelectedAnswer", i)]);
      if (x > 0 && y > 0)
       {
         selectedAnswers.Add(new SelectedAnswer() { questionId = x, answerId = y });
       }
     }
