    class Program
    {
        static void Main(string[] args)
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
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new CustomDataSetConverter());
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(x, settings);
            Console.WriteLine(json);
        }
    }
