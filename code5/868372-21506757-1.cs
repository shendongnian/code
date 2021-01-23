    class Program
    {
        public static void Main()
        {
            var data = new Table {Rows = new List<Row>
                {
                    new Row {Id = 1, ChildId = 2},
                    new Row {Id = 1, ChildId = 3},
                    new Row {Id = 2, ChildId = 88},
                    new Row {Id = 4, ChildId = 5},
                    new Row {Id = 5, ChildId = 6},
                    new Row {Id = 11, ChildId = 12},
                }};
            var ids = GetAllChildIds(1, data.Rows).ToList();
        }
        public static IEnumerable<Row> GetAllChildIds(int parentId, List<Row> data)
        {
            var parents = data.Where(x => x.Id == parentId).ToList();
            return parents.Concat(parents.SelectMany(x => GetAllChildIds(x.ChildId, data)));
        }
    }
    class Row
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
        public override string ToString()
        {
            return Id + " -> " + ChildId;
        }
    }
    class Table
    {
        public List<Row> Rows { get; set; }
    }
