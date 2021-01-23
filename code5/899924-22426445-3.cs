     static void Main(string[] args)
            {
                var theGrade = 80;
                switch (theGrade / 10)
                {
                    case 10:
                    case 9:
                        ShowMessage("You got an A");
                        break;
                    case 8:
                        ShowMessage("You got a B");
                        break;
                    case 7:
                        ShowMessage("You got a C");
                        break;
                    case 6:
                        ShowMessage("You got a D");
                        break;
                    default:
                        ShowMessage("You got a F");
                        break;
    
                }
    
                Console.ReadKey();
            }
