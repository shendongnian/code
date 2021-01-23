    [Table(Name = "Test")]
    public class TableA
    {
        [Column(IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public int prop1 { get; set; }
        [Column]
        public int prop2 { get; set; }
    }
    
    static int main()
    {
        var constr  =   @" Data Source=NOTEBOOK\SQLEXPRESS;Initial Catalog=DemoDataContext;Integrated Security=True " ;
        var context  =   new  DataContext(constr) { Log  =  Console.Out };
        var metaTable  =  context.Mapping.GetTable( typeof (TableA));
        var typeName  =   " System.Data.Linq.SqlClient.SqlBuilder " ;
        var type  =   typeof (DataContext).Assembly.GetType(typeName);
        var bf  =  BindingFlags.Static  |  BindingFlags.NonPublic  |  BindingFlags.InvokeMethod;
        var sql  =  type.InvokeMember( " GetCreateTableCommand " , bf,  null ,  null ,  new [] { metaTable });
            Console.WriteLine(sql);
             // Excute SQL Command 
    }
