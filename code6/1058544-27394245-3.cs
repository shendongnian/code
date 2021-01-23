            int[] grades = { 1, 2, 3, 4, 5 };
            IEnumerable<int> topThreeGrades =
                grades.OrderByDescending(grade => grade).Take(3);
            Console.WriteLine("The top three grades are:");
            foreach (int grade in topThreeGrades)
            {
                Console.WriteLine(grade);
            }
