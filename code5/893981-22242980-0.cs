    public class MyDemo : System.Web.Services.WebService
    {
        [WebMethod (EnableSession = true)]
        public string HelloWorld()
        {
            // get the Count out of Session State
            int? Count = (int?)Session["Count"];
 
            if (Count == null)
                Count = 0;
 
            // increment and store the count
            Count++;
            Session["Count"] = Count;
 
            return "Hello World - Call Number: " + Count.ToString();
        }
    }
    
