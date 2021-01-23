        private class QuestionAndResponses 
        {
             public List<Response> Responses {get;set;}
             public List<Question> Questions {get;set;}
        }
        List<QuestionAndResponses> prescreenerResponses = new List<QuestionAndResponses>();
        for (var i = 0; i < project.preScreeners.Count(); i++) 
        {
             prescreenerResponses.Add(new QuestionAndResponses ()
             {
                   Responses = new List<Response>(project.preScreenerResponses[i].Response),
                   Questions = new List<Question>(project.preScreeners[i].Questions)
             });
        }
