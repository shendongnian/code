    int grade90plus; // fields
    int grade70plus;
    ...
        // inside GetGrade
        if(examScore > 90)
        {
            grade90plus++;
            return "Excellent";
        }
        else
            if(examScore > 70)
            {
                grade70plus++;
                return "Good";
            } 
    ...
    // report
    Console.WriteLine("Excellent: " + grade90plus);
    Console.WriteLine("Good: " + grade90plus);
