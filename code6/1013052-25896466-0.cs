        List<string>[] populate = new List<string>[30];
..
       for (int i = 0; i < q.Count(); i++)
           {
               populate[i] = new List<string>();
               for (int x = 0; x < answersList.Count(); x++)
               {
                   
                   if (answersList[x].QuestionsId == q[i].Qid)
                   {
                       
                       populate[i].Add(answersList[x].answer);
                       System.Diagnostics.Debug.WriteLine("answers " + i + " " + answersList[x].answer);
                   }
               }
               aList.Add(i, populate[i]);
           }
