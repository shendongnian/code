    doc.Descendants("QuestionAnswer").ToList().ForEach(qa =>
    {
        Console.WriteLine("Q: " + qa.Element("Question").Value + "\nA: " + qa.Element("Answer").Value);
        var sqa = qa.Element("SubQuestionAnswer");
        if (sqa != null)
        {
            Console.WriteLine("\tQ: " + sqa.Element("Question").Value + "\n\tA: " + sqa.Element("Answer").Value);
        }
        Console.WriteLine();
     });
