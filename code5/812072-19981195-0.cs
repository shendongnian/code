     public class student
        {
        public int id{get;set;}
        public string StudentName{get;set;}
        public string ClassName{get;set;}
        }
            
    After that create connection with database`.
    You want to select id,StudentName from tableOne and ClassName from tableTwo
   
    string query="SELECT tableOne.id,tableOne.StudentName.....your query with join";
     SQLiteCommand command = dbcon.CreateCommand(query);
    
    var Data = command.ExecuteQuery<student>();
