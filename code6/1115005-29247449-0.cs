    class Program
    {
        static readonly string[] arrID = { "111", "222", "333", "444", "555", "666", "777" };
        static readonly DateTime[] arrDates = new DateTime[]
        {
            new DateTime(2015, 03, 20),
            new DateTime(2015, 03, 20),
            new DateTime(2015, 03, 20),
            new DateTime(2015, 03, 21),
            new DateTime(2015, 03, 21),
            new DateTime(2015, 03, 20),
            new DateTime(2015, 03, 20)
        };
        static readonly string[] arrTime = { "8:20", "8:40", "8:20", "9:10", "8:20", "9:10", "8:20" };
        static void Main(string[] args)
        {
            // Generate intermediate query with grouped, ordered data
            Tuple<DateTime, string>[] q = arrID.Select(CreateRecord)
                .GroupBy(GetKey)
                .OrderBy(GetGroupKey)
                .Select(FlattenGroup)
                .ToArray();
            // Final output arrays here
            string[] str_arrNEWDate = new string[q.Length],
                str_arrNEWTime = new string[q.Length],
                str_arrNEWID = new string[q.Length];
            for (int i = 0; i < q.Length; i++)
            {
                str_arrNEWDate[i] = q[i].Item1.ToString("MM/dd/yyyy");
                str_arrNEWTime[i] = q[i].Item1.ToString("HH:mm");
                str_arrNEWID[i] = q[i].Item2;
                // Diagnostic for demonstration purposes
                Console.WriteLine("{0}: {1}", q[i].Item1, q[i].Item2);
            }
        }
        private static Tuple<DateTime, string> CreateRecord(string id, int index)
        {
            return Tuple.Create(arrDates[index] + TimeSpan.Parse(arrTime[index]), id);
        }
        private static DateTime GetKey(Tuple<DateTime, string> record)
        {
            return record.Item1;
        }
        private static DateTime GetGroupKey(IGrouping<DateTime, Tuple<DateTime, string>> group)
        {
            return group.Key;
        }
        private static Tuple<DateTime, string> FlattenGroup(IGrouping<DateTime, Tuple<DateTime, string>> group)
        {
            return Tuple.Create(group.Key, string.Join(",", group.Select(GetId)));
        }
        private static string GetId(Tuple<DateTime, string> record)
        {
            return record.Item2;
        }
    }
