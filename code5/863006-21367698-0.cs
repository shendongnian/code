    List<QuestionData> questionData =
        xml.Root
           .Elements("Question")
           .Select(q => new QuestionData
                         {
                             QuestionName = (string)q.Element("QuestionName"),
                             Answers = q.Element("Answers")
                                        .Elements("string")
                                        .Select(s => (string)s)
                                        .ToList()
                         }).ToList();
