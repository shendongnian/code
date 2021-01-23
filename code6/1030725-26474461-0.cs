    class DataModel
    {
        public int ID { get; set; }
        public decimal Total { get; set; }
        public override string ToString() { return string.Format("{0}:{1}", ID, Total); }
        public override int GetHashCode() { return ID; }
        public override bool Equals(object other)
        {
            DataModel otherModel = other as DataModel;
            if (otherModel == null) return false;
            return ID == otherModel.ID;
        }
    }
    IEnumerable<DataModel> table1 = new List<DataModel> {
        new DataModel { ID = 1, Total = 20m },
        new DataModel { ID = 2, Total = 90m },
        new DataModel { ID = 3, Total = 130m }
    };
    IEnumerable<DataModel> table2 = new List<DataModel> {
        new DataModel { ID = 1, Total = 10m },
        new DataModel { ID = 2, Total = 30m },
        new DataModel { ID = 4, Total = 15m }
    };
    IEnumerable<DataModel> leftOuterJoin = from one in table1
        join two in table2 on one.ID equals two.ID into temp
        from right in temp.DefaultIfEmpty()
        select new DataModel {
            ID = one.ID,
            Total = one.Total - (right == null ? 0m : right.Total)
        };
    IEnumerable<DataModel> rightOuterJoin = from two in table2
        join one in table1 on two.ID equals one.ID into temp
        from left in temp.DefaultIfEmpty()
        select new DataModel {
            ID = two.ID,
            Total = (left == null ? 0m : left.Total) - two.Total
        };
    IEnumerable<DataModel> difference = leftOuterJoin.Union(rightOuterJoin);
    foreach (DataModel item in difference)
    {
        Console.WriteLine(item);
    }
