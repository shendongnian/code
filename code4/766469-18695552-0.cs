    subgrid = new
    {
        subtotal = 1,
        subpage = 1,
        cell = qstList.Where(q => q.QuestionId == c.QuestionId).SelectMany(q => q.Answers).Select((d, j) => 
        new 
        {
            Id = d.AnswerId,
            Text = d.Text,
            Correctness = d.Correctness,
            Ordinal = d.Ordinal
         }).ToArray()
      }
