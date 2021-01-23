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
            var result = dt.AsEnumerable()
                .Where(row =>
                    row.Field<string>("status")
                    .Any(character =>
                        "iìíị".Contains(character)))
                .ToList();
        }
    }
