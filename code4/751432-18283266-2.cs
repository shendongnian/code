        var letters = from alpha in "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(',')
                      let firstLetters = (from job in JobList
                                          orderby job
                                          group job by job[0].ToString().ToUpper() into firstLetters
                                          select firstLetters.Key)
                      select new
                      {
                          Letter = alpha,
                          IsLink = firstLetters.Contains(alpha)
                      };
                              
        StringBuilder outputHtml = new StringBuilder();
        foreach (var item in letters)
        {
            if (item.IsLink)
            {
                // add html
                outputHtml.AppendFormat("<a href=\"#roulette{0}\">{1}</a> | ", item.Letter, item.Letter);
            }
            else
            {
                // no html
                outputHtml.Append(item.Letter);
                outputHtml.Append(" | ");
            }
        }
        LiteralAlphaGroup.Text = outputHtml.ToString().TrimEnd(" | ".ToCharArray());
