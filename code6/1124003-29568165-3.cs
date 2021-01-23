    public class EmployeeDocument : Document
    {   
         // Other properties that you may have similarly defined ....
    
         public class string TeamName 
         {
            get
            {
                return this.GetValue<string>("TeamName");
            }
            set
            {
                this.SetValue("TeamName", value);
            }
         }
    }
