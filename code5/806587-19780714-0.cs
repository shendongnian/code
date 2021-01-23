    int replyno;
         string Subject = "Re: Hey :) (1)";
         if (Subject.Contains("Re:"))
         {
             try
             {
                 replyno = int.Parse(Regex.Match(Subject, @"(\d+)").Value);
                 replyno++;
                 Subject = Regex.Replace(Subject,@"(\d+)", replyno.ToString());
                 TextBoxSubject.Text = Subject ;
             }
             catch
             {
                 TextBoxSubject.Text = Subject + " (1)";
             }
        
         }
         else
         {
             TextBoxSubject.Text = "Re: " + Subject;
         }
