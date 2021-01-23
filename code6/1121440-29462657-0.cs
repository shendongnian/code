    List<int> Ask(Dictionary<string,string> Questions, List<int> askedList, int count)
    {
        var rnd = new Random();
        int questionIndex = Convert.ToInt32(rnd.Next(0, count));
        while(askedList.Count < count)
        {
            if(!askedList.Any(number => number == questionIndex))
            {
               askedList.Add(questionIndex);
               var questionEntry = Questions.ElementAt(questionIndex);
               string questionText = questionEntry.Key;
               string questionAnswer = questionEntry.Value;
               Console.WriteLine(questionText);
               if (Console.ReadLine() == questionAnswer)
               {
                   Console.WriteLine("Correct!");
               }
               else
               {
                   Console.WriteLine("Wrong!");
               }
            }
            questionIndex = Convert.ToInt32(rnd.Next(0, count));
        }
        return askedList;
    }
