    public class MySessionWrapper
    {
       public string MySessionProperty 
       {
          get
          { 
              return Session["myProperty"] == null ? null : (string) Session["myProperty"]; 
          }
          set
          { 
              Session.Add("myProperty", value);
          }
       }
    }
   
