    public class SomeClass
    {
        public static object ProcessOnInsert(IfxConnection conn, IfxTransaction tran)
        {
            // do something here with conn and tran
        }
    
        public static int Insert(MyDelegateType callback)
    // or
    //    public static int Insert(Func<IfxConnection,IfxTransaction,object> callback)
        {
            // ...
            callback(conn, tran);
            // ...
        }
    
        public static void RunInsert()
        {
            Insert(ProcessOnInsert);
        }
    }
