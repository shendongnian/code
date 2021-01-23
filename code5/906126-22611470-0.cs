    var xDocument = XDocument.Load(@"C:\Users\..\Survey.xml");
    var questionList = xDocument
                           .Element("questions")
                           .Elements("question")
                           .Select(elem => new Questions
            {
                QuestionType = elem.Element("type").Value,
                QuestionText = elem.Element("text").Value,
                SplashScreenText = elem.Element("splashText").Value,
                Choices = elem.Element("choices").Elements("choice").Select(ch =>
                       new Choice
                       {
                           AnswerChoice = ch.Value
                       }).ToArray()
            }).ToList();
