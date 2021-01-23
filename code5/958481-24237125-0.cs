    static void quiz(QuestionStruct[] _quiz)
    {
        bool asked = true;
        int score = 0;
        int AmountAsked = 0;
        string level = "1";
        string ans;
        int pos = 0;
        var pathToFile = @"..\..\..\Files\questions.txt";
        using (StreamReader sr = new StreamReader(pathToFile, true))
        {
             
            while (AmountAsked < 20 || score >= 50)
            {
                Console.Clear();
                //int pos = 0;
               while(!sr.EndOfStream)
                {
                if (level == "1")
                {
                    AmountAsked++;
                    // Remember the order in which you are storing the values to each member of struch
                    questions[pos].number = sr.ReadLine();
                    questions[pos].level = sr.ReadLine();
                    questions[pos].Question = sr.ReadLine();
                    questions[pos].answer = sr.ReadLine();
                    Console.Write(questions[pos].Question);
                    ans = Console.ReadLine();
                    if (ans == questions[pos].answer)
                    {
                        level = "2";
                        score = score + 1;
                        while (questions[pos].Level != "2")
                        {
                            pos++;
                        }
                    }
                }
              } 
