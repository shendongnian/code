    public class TopThree
    {
        public Type SubType {get; set;}
        public IEnumerable<Athlete> Athletes {get; set;}
    }
    (...)
    var topThreePerSubtype = athletes.GroupBy(x => x.GetType()).Select(g => new TopThree() { SubType = g.Key, Athletes = g.OrderByDescending(x => x.averageScores).Take(3)});
