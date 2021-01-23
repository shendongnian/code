    public class DBUpdateTest
    /* public partial class DBUpdateTest*/ //version for database first
    {
       private _DefValue1 = 200;
       private _DefValue2 = 30;
       public DbUpdateTest()
       {
          DefSecond = DateTime.Second;
       }
       public DefSecond { get; set; }
       public DefValue1
       {
          get { return _DefValue1; }
          set { _DefValue1 = value; }
       }
       public DefValue2
       {
          get { return _DefValue2; }
          set { _DefValue2 = value; }
       }
    }
