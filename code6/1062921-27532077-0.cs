    class Program
    {
        static void Main(string[] args)
        {
            List<MyData> md = new List<MyData>();
            md.Add(new MyData() {col1="abc", col2="123", col3="xyz" });
            md.Add(new MyData() { col1 = "ABC", col2 = "gth", col3 = "DDD" });
            md.Add(new MyData() { col1 = "45df", col2 = "987", col3 = "BUR" });
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sample Sheet");
            worksheet.Cell("A1").InsertData(md);
            workbook.SaveAs(@"C:/mydata.xlsx");
        }
    }
    public class MyData
    {
        public string col1 { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
    }
