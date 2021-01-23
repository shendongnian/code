    var questions = exam1.Questions.Take(3).ToArray();
    
    //Should output question1
    Console.WriteLine(questions[0].Content);
    Console.ReadLine();
    //Should output question2 but outputs question1
    Console.WriteLine(questions[1].Content);
    Console.ReadLine();
    //Should output question3 but outputs question1
    Console.WriteLine(questions[2].Content);
    Console.ReadLine();
