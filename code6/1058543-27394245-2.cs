            int[] grades = { 1, 2, 3, 4, 5 };
            IEnumerable<int> topThreeGrades =
                grades.Take(3).OrderByDescending(grade => grade);
            Console.WriteLine("The top three grades are:");
            foreach (int grade in topThreeGrades)
            {
                Console.WriteLine(grade);
            }
