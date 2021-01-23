    int studentcount = 0, i = 0, x = 0, highestScore = 0;
    string studentname = "", highestScoreStudentName = "";
    Console.WriteLine("Enter how many students there are: ");
    
    studentcount = Convert.ToInt32(Console.ReadLine());
    {
        for (i = 1; i <= studentcount; i++)
        {
            Console.WriteLine("Enter students name: ");
            studentname = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter students score: ");
            x = Convert.ToInt32(Console.ReadLine());
            if (x > highestScore)
            {
                highestScore = x;
                highestScoreStudentName = studentname;
            }
        }
    }
