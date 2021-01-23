    class StudentScores1
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Biology { get; set; }
        public int Chemistry { get; set; }
        public int Physics { get; set; }
        public int English { get; set; }
        public int French { get; set; }
        public int Mathematics { get; set; }
    }
    class CombinedScores
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public int Languages { get; set; }
        public int Mathematics { get; set; }
        public int Sciences { get; set; }
    }
    …
    static IEnumerable<StudentScores1> ParseScores1(string inputPath)
    {
        using (var sr = new StreamReader(inputPath))
        {
            while (!sr.EndOfStream)
            {
                var data = sr.ReadLine().Split(',');
                yield return
                    new StudentScores1
                    {
                        Id = int.Parse(data[0]),
                        FirstName = data[1],
                        LastName = data[2],
                        Biology = int.Parse(data[3]),
                        Chemistry = int.Parse(data[4]),
                        Physics = int.Parse(data[5]),
                        English = int.Parse(data[6]),
                        French = int.Parse(data[7]),
                        Mathematics = int.Parse(data[8])
                    };
            }
        }
    }
    static int Average(params int[] inputs)
    {
        return inputs.Sum() / inputs.Length;
    }
    static IEnumerable<CombinedScores> CombineScores1(
        IEnumerable<StudentScores1> scores)
    {
        return scores.Select(
            s =>
            new CombinedScores
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Languages = Average(s.English, s.French),
                Sciences = Average(s.Biology, s.Chemistry, s.Physics)
            });
    }
    static void WriteOutput(
        IEnumerable<CombinedScores> combinedScores, string outputPath)
    {
        using (var sw = new StreamWriter(outputPath))
        {
            foreach (var scores in combinedScores)
            {
                string outputLine = string.Format(
                    "{0:d3} {1} {2} {3:d3} {4:d3} {5:d3}",
                    scores.Id, scores.FirstName, scores.LastName,
                    scores.Languages, scores.Mathematics, scores.Sciences);
                sw.WriteLine(outputLine);
            }
        }
    }
