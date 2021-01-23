    public class DbColumnInfoAttribute : System.Attribute
    {
        public string ColumnName {get; set; }
        public bool Required { get; set; }
        public DbColumnInfoAttribute( string name, bool req){
           ColumnName = name;
           Required = req;
        }
    }
