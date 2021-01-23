    List<KeyValuePair<string,string>> allQuestionAnswers = doc.Descendants("QuestionAnswer").Union(doc.Descendants("SubQuestionAnswer"))
        .Select(qa=>new KeyValuePair<string,string>(qa.Element("Question").Value, qa.Element("Answer").Value)).ToList();
    
    foreach (var pair in allQuestionAnswers)
    {
        Console.WriteLine("Q: " + pair.Key +"\nA: " + pair.Value + "\n");
    }
