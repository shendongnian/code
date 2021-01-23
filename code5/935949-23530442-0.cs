    XDocument xmlDoc = XDocument.Load(@"C:\Test\Sample.xml");
    var users = xmlDoc.Elements("User");
    foreach(var user in users)
    {
        var qaList = user.Element("QAList");
        foreach(var qa in qaList.Elements("QA"))
        {
            //at this point, you should have access the <Question> node e.g.
            string question = qa.Element("Question").Value;
    
            //and the list of answers would be similar to before
            var answers = qa.Element("Answers");
            foreach(var answer in answers.Elements("Answer"))
            {
                //now answer.Value should be the text of the answer
            } 
        }        
    }
