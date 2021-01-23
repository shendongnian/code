    public class Order : IHasId<long>
    {
        [AutoIncrement]
        public long Id { get; set; }
        [References(typeof(Material))]
        public long MaterialId { get; set; }
        [Reference]
        public Material Material { get; set; }
    }
    public class Material : IHasId<long>
    {
        [AutoIncrement]
        public long Id { get; set; }
        public string Name { get; set; }
    }
    db.Insert(new Material { Name = "A" });
    db.Insert(new Material { Name = "B" });
    db.Insert(new MaterialOrder {
        MaterialId = 2,
    });
    var order = db.LoadSingleById<Order>(1);
    order.PrintDump(); //recursively print object graph
