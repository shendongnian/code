    int YourExamScore;
    Console.WriteLine("Input Your Exam Score");
    YourExamScore = Convert.ToInt32(Console.ReadLine());
            List<ScoreRange> ranges = new List<ScoreRange>();
            ranges.Add(new ScoreRange() {
                Min = 0,
                Max = 49,
                Message = "You Have a Satisfactory Score"
            });
            ranges.Add(new ScoreRange() {
                Min = 50,
                Max = 69,
                Message = "You Have a Satisfactory Score"
            });
            ranges.Add(new ScoreRange() {
                Min = 70,
                Max = 89,
                Message = "You Have a Good Score"
            });
            ranges.Add(new ScoreRange() {
                Min = 90,
                Max = 100,
                Message = "You Have An Excellent Score"
            });
            string message = ranges.First(x => x.Min <= YourExamScore && YourExamScore <= x.Max).Message;
            Console.WriteLine(message);
