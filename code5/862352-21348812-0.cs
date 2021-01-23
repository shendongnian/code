    [Httppost]
    public ActionResult Add(Interview interview, FormCollection formCollection)
      {
    string[] questions = formCollection.AllKeys.Where(c => c.StartsWith("questionText")).ToArray(); //search question input
      if (questions.Length > 0)
        {
         interview.Questions = new List<Question>();
         foreach (var question in questions)
          {
           if (!string.IsNullOrWhiteSpace(formCollection[question]))
          interview.Questions.Add(new Question() { Text = formCollection[question], InterviewID = interview.InterviewID });
          }
    }
