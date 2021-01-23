    public static string GetStringData(IDataReader reader)
    {
      var ord_name = reader.GetOrdinal("Name");
       if(reader.Read())
         return reader.GetString(ord_name);
       return null;
    }
    public static IEnumerable<Foo> GetFoos(IDataReader reader)
    {
       var ord_name = reader.GetOrdinal("Name");
       var foos = new List<Foo>();
       while(reader.Read())
         foos.Add(new Foo {Name = reader.GetString(ord_name)});
       return foos;
    }
    static void Main(string[] args)
    {
       var program = new Program();
       try
       {
          var name = program.LoadDataToReader("SELECT name FROM thename", GetStringData);
       }
       catch(Exception ex)
       {
          MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
       try
       {
          var foos = program.LoadDataToReader("SELECT foos FROM footable", GetFoos);
       }
       catch(Exception ex)
       {
          MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
    }
