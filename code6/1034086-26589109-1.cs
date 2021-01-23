    public class EmployeeInputModel{
         public string Name {get;set;}
         public List<DepartmentInputModel> Departments{get;set;}
    }
    
    public class DepartmentInputModel{
      public int Id;
      public string Name;
    }
