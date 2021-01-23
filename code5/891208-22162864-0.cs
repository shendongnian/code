    public class Foo {
        public int ID { get; set; }
        public int? Order { get; set; }
    
        public Foo(int id, int? order) {
            ID = id;
            Order = order;
        }
    }
    
    static void Main(string[] args) {
    
        var ListT = new List<int> {1090,1089};
        var ListTOrder = ListT.Select((x, index) => new { Item = x, Index = index }).ToDictionary(x => x.Item, x => x.Index);
    
        List<Foo> ListB = new List<Foo> {
            new Foo(1089, 1),
            new Foo(1089, 3),
            new Foo(1089, 4),
            new Foo(1089, null),                
            new Foo(1090, 1),
            new Foo(1090, 3),
            new Foo(1090, 4)
        };
    
        ListB = ListB.OrderBy(x => ListTOrder[x.ID]).ThenBy(x => x.Order).ToList();
    }
