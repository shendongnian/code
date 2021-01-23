    string fileName = "TextFile1.txt";
    List<QuestionUnit> readQuestions = new List<QuestionUnit>();
    using (StreamReader myReader = new StreamReader(fileName))
    {
        while (!myReader.EndOfStream)
        {
            QuestionUnit newQuestion = new QuestionUnit();
            newQuestion.M_Question  = myReader.ReadLine();
            newQuestion.M_Answers = myReader.ReadLine();
            newQuestion.M_CorrectAnswers = myReader.ReadLine();
            newQuestion.M_Explanation = myReader.ReadLine();
            
            readQuestions.Add(newQuestion);
        }
    }
    return readQuestions;
