    using System.Web.Script.Serialization;
    public class ClassA
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public List<ClassB> Details { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet x = new DataSet();
            DataTable a = x.Tables.Add("A");
            a.Columns.Add("Type");
            a.Columns.Add("Value");
            a.Rows.Add("A", "100");
            DataTable b = x.Tables.Add("B");
            b.Columns.Add("Name");
            b.Columns.Add("Age");
            b.Columns.Add("Gender");
            b.Rows.Add("John", "45", "M");
            b.Rows.Add("Sebastian", "34", "M");
            b.Rows.Add("Marc", "23", "M");
            b.Rows.Add("Natalia", "34", "F");
            var s = FromDataRow(a.Rows[0], b.AsEnumerable());
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string output = jss.Serialize(s);
        }
        public static ClassA FromDataRow(DataRow row, IEnumerable<DataRow> relatedRows)
        {
            var classA = new ClassA
            {
                Type = (string)row["Type"],
                Value = (string)row["Value"],
                Details = relatedRows.Select(r => new ClassB
                {
                    Name = (string)r["Name"],
                    Age = (string)r["Age"],
                    Gender = (string)r["Gender"]
                }).ToList()
            };
            return classA;
        }
    }
    public class ClassB
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
    }
