    public static void AddUser(NameValue[] formVars)
            {
               //formvars will contain list of values
                foreach (NameValue nv in formVars)
                {
                    // strip out ASP.NET form vars like _ViewState/_EventValidation  
                    if (!nv.name.StartsWith("__"))
                    {
                       string ss = nv.value; 
                      
                    }
                }  
                return;
            }
    
    
    
            public class NameValue
            {
                public string name { get; set; }
                public string value { get; set; }
            }  
