        static void Main(string[] args)
        {
            var dt = new DataTable();
            dt.Columns.Add("A", typeof(int));
            dt.Columns.Add("B", typeof(string));
            dt.Columns.Add("C", typeof(string));
            dt.Columns.Add("D", typeof(string));
            dt.Columns.Add("E", typeof(string));
            dt.Columns.Add("F", typeof(string));
            dt.Columns.Add("G", typeof(string));
            dt.Columns.Add("H", typeof(decimal));
            dt.Columns.Add("I", typeof(decimal));
            dt.Columns.Add("J", typeof(decimal));
            dt.Columns.Add("K", typeof(string));
            dt.Columns.Add("L", typeof(string));
            dt.Columns.Add("M", typeof(string));
            dt.Rows.Add(1, "KT049014", "L1", "Ghoousunnisa", "(F)", "9999999999", "Nellore", 550, 55, 495, "API", "EasyBus", "Agent");
            dt.Rows.Add(2, "KT049014", "L2", "Ghoousunnisa", "(F)", "9999999999", "Nellore", 550, 55, 495, "API", "EasyBus", "Agent");
            dt.Rows.Add(3, "KT049014", "R1", "Ghoousunnisa", "(F)", "9999999999", "Nellore", 550, 55, 495, "API", "EasyBus", "Agent");
            dt.Rows.Add(4, "KT049014", "R2", "Ghoousunnisa", "(F)", "9999999999", "Nellore", 550, 55, 495, "API", "EasyBus", "Agent");
            var datas =
                dt.AsEnumerable()
                .GroupBy(row => row[1])
                .Select((group, i) => new {A = i + 1, B = group.Key, Others = combine(dt.Columns, group)});
            var result = dt.Clone();
            foreach (var d in datas)
            {
                var row = result.Rows.Add(d.A, d.B);
                for (int i = 0; i < d.Others.Count(); i++)
                    row[i + 2] = d.Others.ElementAt(i);
            }
        }
        private static IEnumerable<object> combine(DataColumnCollection columns, IGrouping<object, DataRow> group)
        {
            for (int i = 2; i < columns.Count; i++)
            {
                if (columns[i].DataType == typeof(string))
                    yield return string.Join(",", group.Select(r => r.Field<string>(i)).Distinct());
                else
                    yield return group.Sum(r => r.Field<decimal>(i));
            }
        }
    }
