    public class LinqTable
    {
    
        public LinqTable()
        {
    
        }
    
        public LinqTable(DataTable sourceTable)
        {
            LoadFromTable(sourceTable);
        }
    
        public List<LinqRow> Rows = new List<LinqRow>();
            
        public List<string> Columns
        {
            get
            {
                var columns = new List<string>();
    
                if (Rows != null && Rows.Count > 0)
                {                    
                    Rows[0].Fields.ForEach(field => columns.Add(field.Name));
                }
                    
                return columns;
            }
        }
    
        public void LoadFromTable(DataTable sourceTable)
        {
            sourceTable.Rows.Cast<DataRow>().ToList().ForEach(row => Rows.Add(new LinqRow(row)));
        }
    
        public DataTable AsDataTable()
        {
            var dt = new DataTable("data");
    
            if (Rows != null && Rows.Count > 0)
            {
                Rows[0].Fields.ForEach(field =>
                    {
                        dt.Columns.Add(field.Name, field.DataType);
                    });
    
                Rows.ForEach(row=>
                    {
                        var dr = dt.NewRow();
    
                        row.Fields.ForEach(field => dr[field.Name] = field.Value);
    
                        dt.Rows.Add(dr);
                    });
            }
    
            return dt;
        }
    }
    
    public class LinqRow 
    {
        public List<LinqField> Fields = new List<LinqField>();
    
        public LinqRow()
        {
                
        }
    
        public LinqRow(DataRow sourceRow)
        {
            sourceRow.Table.Columns.Cast<DataColumn>().ToList().ForEach(col => Fields.Add(new LinqField(col.ColumnName, sourceRow[col], col.DataType)));
        }
    
        public object this[int index]
        {
            get
            {
                return Fields[index].Value;
            }
        }
        public object this[string name]
        {
            get
            {
                return Fields.Find(f => f.Name == name).Value;
            }
        }
    
        public DataTable AsSingleRowDataTable()
        {
            var dt = new DataTable("data");
    
            if (Fields != null && Fields.Count > 0)
            {
                Fields.ForEach(field =>
                {
                    dt.Columns.Add(field.Name, field.DataType);
                });
    
                var dr = dt.NewRow();
    
                Fields.ForEach(field => dr[field.Name] = field.Value);
    
                dt.Rows.Add(dr);
            }
    
            return dt;
        }
    }
    
    public class LinqField
    {
        public Type DataType;
        public object Value;
        public string Name;
    
        public LinqField(string name, object value, Type dataType)
        {
            DataType = dataType;
            Value = value;
            Name = name;
        }
    
        public LinqField(string name, object value)
        {
            DataType = value.GetType();
            Value = value;
            Name = name;
        }
    
        public override string ToString()
        {
            return Value.ToString();
        }      
    }
