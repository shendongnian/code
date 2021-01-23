    [Test]
    public void TestRulesUsingList2()
    {
        var rules = new IRules[]{ new RuleNumberOne(), new RuleNumberTwo(), 
            new DefaultRule() };
        var date = new Oobject { Time = 1, Something = 1 };
        var rate = rules.First(x => x.Execute(date)).Value;
        Assert.That( rate, Is.EqualTo(.75m));
    }
    public class Oobject
    {
        public int Time { get; set; }
        public int Something { get; set; }
    }
    public interface IRules
    { 
        bool Execute(Oobject date);
        decimal Value { get; }
    }
    public class RuleNumberOne : IRules
    {
        public bool Execute(Oobject date)
        {
            return date.Time > 0 && date.Something <= 499;
        }
        public decimal Value
        {
            get { return .75m; }
        }
    } 
    public class RuleNumberTwo : IRules
    {
        public bool Execute(Oobject date)
        {
            return date.Time >= 500 && date.Something <= 999;
        }
        public decimal Value
        {
            get { return .85m; }
        }
    } 
    public class DefaultRule : IRules
    {
        public bool Execute(Oobject date)
        {
            return true;
        }
        public decimal Value
        {
            get { return 0; }
        }
    }
