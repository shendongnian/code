    private static void Main(string[] args)
    {
        const int QuestionNumbers = 10;
        var Answer = new char[QuestionNumbers];
        Question[] MCQ = new Question[QuestionNumbers];
        MCQ[0] = new Question(Slaughterhouse);
        MCQ[1] = new Question(Frankenstein);
        MCQ[2] = new Question(Things);
        MCQ[3] = new Question(Jane);
        MCQ[4] = new Question(Kill);
        MCQ[5] = new Question(Beloved);
        MCQ[6] = new Question(Gatsby);
        MCQ[7] = new Question(Catcher);
        MCQ[8] = new Question(Pride);
        MCQ[9] = new Question(Nineteen);
        for (int i = 0; i < QuestionNumbers; i++)
        {
            Console.WriteLine("Question {0}", i + 1);
            Answer[i] = MCQ[i]();
            // return bool since you want to validate an answer.
            var result =  IsValidAnswer(i + 1, Answer[i]);
                                // this is an if/else conditional statment, its called a ternary expression
            Console.WriteLine(result ? "Answer is valid" : "Answer is not valid");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
    private static bool IsValidAnswer(int Nbr, char Ans)
    {
        // if you really wanted to use a method. 
        var correctAnswer = default(char);
        switch (Nbr)
        {
            case 1:
                correctAnswer = 'b';
                break;
            case 2:
                //.. 
                break;
        }
        return char.ToUpperInvariant(Ans) == char.ToUpperInvariant(correctAnswer);
    }
