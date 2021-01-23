    rfc.Select(r=>
        new AnswerDetail
        {
            AnswerId =r.AnswerId,
            Text=r.Text,
            Response=r.Response,
            Correct=afd.Where(c=>c.AnswerId==r.AnswerId).Single().Correct
        }
               );
