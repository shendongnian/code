    class SchoolFundRaising
    {
        private Dictionary<string, List<double>> entries = new Dictionary<string, List<double>>();
        public void displayContributionsSummary()
        {
            Console.WriteLine("Grade \t Num of Contributions \t Total Contribution \t Average contribution");
            foreach (string key in entries.Keys)
            {
                List<double> contri = entries.FirstOrDefault(k => k.Key == key).Value;
                Console.WriteLine("Grade {0} \t {1}         \t      {2}              \t {3}", key, contri.Count, contri.Sum(), contri.Average());
            }
        }
        public void getContributionsGrades()
        {
            int grade = 0;
            double contribution;
            while (grade != 999)
            {
                Console.WriteLine("Please Enter your grade(6, 7, 8). Enter 999 to quit.");
                grade = Convert.ToInt32(Console.ReadLine());
                if (grade >= 6 && grade <= 8)
                {
                    Console.WriteLine("Please Enter the Amount you want to contribute. ");
                    contribution = Convert.ToDouble(Console.ReadLine());
                    if (!entries.ContainsKey(grade.ToString()))
                    {
                        List<double> dummyList = new List<double>();
                        dummyList.Add(contribution);
                        entries.Add(grade.ToString(), dummyList);
                    }
                    else
                    {
                        entries.First(k => k.Key == grade.ToString()).Value.Add(contribution);
                    }
                }
                else
                {
                    if (grade == 999)
                    {
                        Console.WriteLine("Done...");
                    }
                    else
                    {
                        Console.WriteLine("Grade should either be 6,7 or 8");
                    }
                }
            }
        }
     }
