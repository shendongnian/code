    public class DBObject 
    {
        public ObjectId Id {get;set;}
    }
    public class Department : DBObject 
    {
      // ...
    }
 
    public class EmployeeDB : DBObject
    {
        public ObjectId DepartmentId {get;set;}
    }
