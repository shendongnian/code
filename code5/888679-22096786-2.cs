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
             MyJsonFriendlyClass buy=new MyJsonFriendlyClass() {name: "BUY"};
             MyJsonFriendlyClass sell=new MyJsonFriendlyClass() {name: "SELL"};
             foreach(DataRow dr in dt)
             {
                 buy.data.Add(dr["AXA"]);//you may have to convert based on data type of your column
                 sell.data.Add(dr["BXB"]);
             }
             returndata.Add(buy);
             returndata.Add(sell);
             //go through your data table and create new instances of MyJsonFriendlyClass
             //add the new instances to return data
             return returndata;      
        }
    }
