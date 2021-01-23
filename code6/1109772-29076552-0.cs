    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TableNameAttribute : Attribute
    {
      public string TableName { get; set; }
    }
    public class BaseLookup<TSelfReferenceType>
    {
      public static string TABLE_NAME
      {
        get 
        { 
          var attributes = typeof(TSelfReferenceType).GetCustomAttributes(typeof(TableNameAttribute), false); 
          if (attributes == null || attributes.Length == 0)
          {
            return null;
          }
          return ((TableNameAttribute)attributes[0]).TableName;
        }
      }
    }
    [TableName(TableName = "MyLookup")]
    public class MyLookup : BaseLookup<MyLookup>
    {
    }
    [TableName(TableName = "ChildLookup")]
    public class ChildLookup : BaseLookup<ChildLookup>
    {
    }
    // write out MyLookup
    Console.Out.WriteLine(MyLookup.TABLE_NAME);
    // write out ChildLookup
    Console.Out.WriteLine(ChildLookup.TABLE_NAME);
