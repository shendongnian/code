    public class Person
    {
        [EpplusIgnore]
        public int Key { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var demoData = new List<Person> { new Person { Key = 1, Age = 40, Name = "Fred" }, new Person { Key = 2, Name = "Eve", Age = 21 } };
            FileInfo fInfo = new FileInfo(@"C:\Temp\Book1.xlsx");
            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("People");
                ws.Cells[1, 1].LoadFromCollectionFiltered(demoData);
                
                excel.SaveAs(fInfo);
            }
        }
    }
