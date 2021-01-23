    var pathToCust = @"..\..\..\Files\questions.txt";
    using (StreamReader sr = new StreamReader(pathToCust, true))
    {
        while (!CustomerNumberMatch)
        {
            RecCount = 0;
            questions[RecCount].QuestionNum = sr.ReadLine();
            if (questions[RecCount].QuestionNum == NumberSearch)
            {
                Console.Clear();
                Console.WriteLine("Question Number: {0}", questions[RecCount].QuestionNum);
                
                questions[RecCount].Level = sr.ReadLine();
                Console.WriteLine("Level: {0}", questions[RecCount].Level);
                
                questions[RecCount].Question = sr.ReadLine();
                Console.WriteLine("Question: {0}", questions[RecCount].Question);
                
                questions[RecCount].answer = sr.ReadLine();
                Console.WriteLine("Answer: {0}", questions[RecCount].answer);
                
                CustomerNumberMatch = true;
            }
            RecCount++;
        }
    }
