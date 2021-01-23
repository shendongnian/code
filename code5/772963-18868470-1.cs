    rfc.Select(r=>
        new AnswerDetail
        {
            AnswerId =r.AnswerId,
            Text=r.Text,
            Response=r.Response,
            Correct=afd.Single(c=>c.AnswerId==r.AnswerId).Correct
        }
               );
