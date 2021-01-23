    public interface ISomeInterface
    {
        string Id { get; set; }
        string Name { get; set; }
        DateTime? DateScheduled { get; set; }
        DateTime? DateUnscheduled { get; set; }
        ISomeInterface SomeNeededObject { get; set; }
    }
    public class SomeClass : ISomeInterface
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateScheduled { get; set; }
        public DateTime? DateUnscheduled { get; set; }
        public ISomeInterface SomeNeededObject { get; set; }
    }
    var c = new SomeClass
    {
        Id = "1",
        Name = "Name1",
        DateScheduled = DateTime.Now,
    };
    Redis.StoreAsHash(c);
    var fromHash = Redis.GetFromHash<SomeClass>("1");
    fromHash.PrintDump();
