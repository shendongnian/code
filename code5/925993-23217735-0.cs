      public static List<Answer> GetDetailedAnswers(string Tag)
    {
        using (Database db = new Database())
        {
            List<Answer> answer = 
                         (from quest in db.Question
                         join answ in db.Answer on quest.ID equals answ.QuestionID
                         join deal in db.Dealer on answ.DealerID equals deal.ID
                         join country in db.Country on deal.CountryID equals country.CountryID
                         where quest.ParentSection == Tag
                         select new Answer
                         { 
                                      ParentSection = quest.ParentSection, 
                                      Section = quest.Section, 
                                      Dealer = deal.Name, 
                                      OriginalAnswer = answ.Original,
                                      EngAnswer = answ.English,
                                      Region = country.Country
                         }).ToList();
            return answer;
        }
    }
