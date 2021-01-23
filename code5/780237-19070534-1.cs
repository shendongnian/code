    public class Program
    {
        public static char DecisionSign = ' ';
        public static double TotalMarkOfFirstStudent = 0;
        public static double TotalMarkOfSecondStudent = 0;
        public static double inputValue = 0;
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter mark for student 1: ");
            while (DecisionSign != 'n')
            {
                CalculateFirstStudentResult();
            }
            DecisionSign=' ';
            Console.WriteLine("Enter mark for student 2: ");
            while (DecisionSign != 'n')
            {
                CalculateSecondStudentResult();
            }
            Console.WriteLine("Student 1 got total : " + TotalMarkOfFirstStudent);
            Console.WriteLine("Student 2 got total : " + TotalMarkOfSecondStudent);
            Console.ReadKey();
        }
        public static char CalculateFirstStudentResult()
        {
            DecisionSign = ' ';
            Console.WriteLine("Enter Value : ");
            inputValue = Convert.ToDouble(Console.ReadLine());
            if (inputValue >= 0 && inputValue <= 100)
            {
                TotalMarkOfFirstStudent += inputValue;
                Console.WriteLine("Any more data? Enter 'y' or 'n' then return");
            }
            else
            {
                CalculateFirstStudentResult();
            }
            return DecisionSign = Convert.ToChar(Console.ReadLine());
        }
        public static char CalculateSecondStudentResult()
        {
            DecisionSign = ' ';
            Console.WriteLine("Enter Value : ");
            inputValue = Convert.ToDouble(Console.ReadLine());
            if (inputValue >= 0 && inputValue <= 100)
            {
                TotalMarkOfSecondStudent += inputValue;
                Console.WriteLine("Any more data? Enter 'y' or 'n' then return");
            }
            else 
            {
                CalculateSecondStudentResult();
            }
            return DecisionSign = Convert.ToChar(Console.ReadLine());
        }
    }
