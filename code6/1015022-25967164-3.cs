        static void Main(string[] args)
        {
            String StudentName;
            //Error Trapping
            try
            {
                Console.WriteLine("Welcome to The GPA Calculator");
                Console.WriteLine("Hit any key to continue...");
                Console.ReadKey();
                Console.Write("Please enter your name: ");
                StudentName = Convert.ToString(Console.ReadLine());
                List<double> gradeInfoList = new List<double>();
                List<int> creditList = new List<int>();
                bool brakeLoop = false;
                while (!brakeLoop)
                {
                    gpa.Add(InputGradeInfo(creditList));
                    Console.WriteLine("Do you want to continue(y/n): ");
                    brakeLoop = Console.ReadLine() != "y";
                }
                Console.WriteLine(StudentName + " GPA is: " + gradeInfoList .Sum()/creditList.Sum());
            }
            //Error Repsonse
            catch (System.Exception e)
            {
                Console.WriteLine("An error has Occurred");
                Console.WriteLine("The error was: {0}", e.Message);
                //Belittle the User
                Console.WriteLine("Good Job, you Broke it.");
                Console.ReadLine();
            }
        }
        public static double InputGradeInfo(List<int> creditList)
        {
            String ClassName;
            Char LetterGrade;
            Double LetterGradeValue;
            Double CreditHours;
            Double ValueOfClass;
            Console.Write("Please enter the class title: ");
            ClassName = Convert.ToString(Console.ReadLine());
            Console.Write("Please enter the total credits this class is worth: ");
            CreditHours = Convert.ToDouble(Console.ReadLine());
            creditList.Add(CreditHours);
            Console.Write("Please enter the grade letter recived: ");
            LetterGrade = Convert.ToChar(Console.ReadLine().ToUpper());
            switch (LetterGrade)
            {
                case 'A': LetterGradeValue = 4;
                    break;
                case 'B': LetterGradeValue = 3;
                    break;
                case 'C': LetterGradeValue = 2;
                    break;
                case 'D': LetterGradeValue = 1;
                    break;
                case 'F': LetterGradeValue = 0;
                    break;
                default: LetterGradeValue = 0;
                    break;
            }
            ValueOfClass = CalculateClass(LetterGradeValue, CreditHours);
            return ValueOfClass;
        }
        public static double CalculateClass(double LetterGrade, double CreditHours)
        {
            Double CreditTotal;
            CreditTotal = CreditHours * LetterGrade;
            return CreditTotal;
        }
