    bool errorHandling = true;
    while (errorHandling)
    {
        try
        {
            string userAnswer = Console.ReadLine();
            int numberEntered = Convert.ToInt32(userAnswer);
    
            switch (numberEntered)
            {
                case 1:
                  singleGrade.grapher(acount, bcount, ccount, dcount, ecount, fcount);
                  break;
                case 2:  
                  readIn.Classes(SingleGrade[1]);
                   break;
                        
                case 3:
                  countAll.allGrades(multiGrade);
                  break;
                default:
                  errorHandling = false;
            }
        }
        catch (FormatException a)
        {
            Console.WriteLine(a.Message);
            //Console.WriteLine("Error - please enter a number between 1 & 6.");
        }
    } // end of While loop 
