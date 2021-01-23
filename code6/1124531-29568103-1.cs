    public class Department
    {
      public int ID { get; private set; }
  
      //follow this pattern for property values that need to be populated from a data store.
      private string name;
      public string Name
      {
         get{ EnsureLoad(); return name; }
         set{ EnsureLoad(); name = value; }
      }
      public static Department HR{ get{ return GetEmptyDepartment( 1 ); } }
      public static Department IT{ get{ return GetEmptyDepartment( 2 ); } }
      private static Department GetEmptyDepartment(int departmentId)
      {
           return new Department()
           {
               ID = departmentId
           };
      }
      private void EnsureLoad()
      {
         //if not loaded
         //lazy load properties
      }
    }
