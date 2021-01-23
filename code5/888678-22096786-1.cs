    public class MyJsonFriendlyClass()
    {
        public string name {get;set;}
        public Dictionary<string,string> data {get;set;}
    
        public MyJsonFriendlyClass()
        {
            data=new Dictionary<string,string>();
        }
    
        public static List<MyJsonFriendlyClass> GetJsonFriendlyClasses(DataTable dt)
        {
             List<MyJsonFriendlyClass> returndata=new List<MyJsonFriendlyClass>();
             //go through your data table and create new instances of MyJsonFriendlyClass
             //add the new instances to return data
             return returndata;      
        }
    }
