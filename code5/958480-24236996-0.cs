    public void Quiz()
    {
        List<QuestionStruct> questions = GetQuestions(@"..\..\..\Files\questions.txt");
    
        RunQuiz(questions);
    }
    
    
    // My job is to parse the file
    public List<QuestionStruct> GetQuestions(string pathToFile)
    {
        List<QuestionStruct> questions = new List<QuestionStruct>();
    
        using (StreamReader sr = new StreamReader(pathToFile, true))
        {
            while (!sr.EndOfStream)
            {
                QuestionStruct q = new QuestionStruct();
                q.Number = sr.ReadLine();
                q.Level = sr.ReadLine();
                q.Question = sr.ReadLine();
                q.Answer = sr.ReadLine();
    
                questions.Add(q);
            }
        }
    
        return questions;
    }
    
    
    // My job is to run the quiz
    public void RunQuiz(List<QuestionStruct> questions)
    {
    
        bool asked = true;
        int score = 0;
        int AmountAsked = 0;
    
        string level = "1";
        string ans;
        int pos = 0;
    
        foreach (QuestionStruct question in questions)
        {
            if (!(AmountAsked < 20 || score >= 50))
                break;
                
            Console.Clear();
            //int pos = 0;
            if (level == "1")
            {
                AmountAsked++;
    
                Console.Write(question.Question);
                ans = Console.ReadLine();
    
                if (ans == question.Answer)
                {
                    level = "2";
                    score = score + 1;
                    while (question.Level != "2")
                    {
                        pos++;
                    }
                }
            }
        }
    }
