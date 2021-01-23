    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Your Exam Score");
            var examScore = Convert.ToInt32(Console.ReadLine());
            var grade = GetGrade(examScore);
            Console.WriteLine(grade);
        }
        private static string GetGrade(int examScore)
        {
            if (examScore >= 90)
                return "Excellent";
            if (examScore >= 70)
                return "Good";
            return "Satisfactory";
        }
    }
