    public class student
    {
        public int id {get;set;}
        public string name {get;set;}
        public long zipcode {get;set;}
    }
    
    SelectFromStudent()
    {
        string query="select id,name,zipcode from student";
        List<student> studentList = SelectFromTable<student>(query);
    }
        
    List<T> SelectFromTable<T>(String statement) where T : new()
    {
        SQLiteCommand cmd = MySqlLiteDB.CreateCommand(statement);
        var lst = cmd.ExecuteQuery<T>();
        return lst.ToList<T>();
    }
    
  
