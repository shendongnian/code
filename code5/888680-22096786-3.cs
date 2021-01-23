    public class MyJsonFriendlyClass()
    {
        public string name {get;set;}
        public List<int> data {get;set;}
    
        public MyJsonFriendlyClass()
        {
            data=new List<int>();
        }
    
        public static List<MyJsonFriendlyClass> GetJsonFriendlyClasses(DataTable dt)
        {
             List<MyJsonFriendlyClass> returndata=new List<MyJsonFriendlyClass>();
             MyJsonFriendlyClass buy=new MyJsonFriendlyClass();
             buy.name="BUY";
             MyJsonFriendlyClass sell=new MyJsonFriendlyClass();
             sell.name="SELL";
             foreach(DataRow dr in dt)
             {
                 buy.data.Add(dr["AXA"]);//you may have to convert based on data type of your column
                 sell.data.Add(dr["BXB"]);
             }
             returndata.Add(buy);
             returndata.Add(sell);
             return returndata;      
        }
    }
