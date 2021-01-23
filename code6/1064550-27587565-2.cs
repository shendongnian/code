    public class Row
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public double Value {get;set;}
        
        public Row(string rowStr)
        {
            string[] cols = rowStr.Split(',');
            Id = int.Parse(cols[0]);
            Name = cols[1];
            Value = double.Parse(cols[2]);
        }
        
        public string AsString()
        {
            return string.Format("{0},{1},{2}", Id, Name, Value);
        }
    }
    
    
    List<Row> rows = new List<Row>();
    using (FileStream reader = File.OpenRead(@"C:\File.csv"))
    {
        string rowStr = reader.ReadLine(); 
        rows.Add(new Row(rowStr));  
    }
    
    rows = rows.OrderBy(r=>r.Id);
    rows = rows.OrderByDescending(r=>r.Name);
    
    foreach(Row row in rows)
    {
       outputFile.WriteLine(row.AsString);
    }
