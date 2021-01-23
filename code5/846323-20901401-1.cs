    using System.Linq;
    using System.Data;
    static class Program
    {
        static void Main()
        {
            var dt = new DataTable();
            var column = dt.Columns.Add("status");
            dt.Rows.Add("Binh");
            dt.Rows.Add("Bình");
            dt.Rows.Add("Bính");
            dt.Rows.Add("Bịnh");
            dt.Rows.Add("Bỉnh");
            dt.Rows.Add("Aing");
            var result = dt.AsEnumerable()
                .Where(row => 
                    Regex.Match(row.Field<string>("status"), @"B[iìíị]nh").Success)
                .ToList();
        }
    }
