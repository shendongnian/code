    private void Assign(DataTable table,string value)
    {
      if (!String.IsNullOrWhitespace(value))
      {
         table.Value = value; 
      }
    }
