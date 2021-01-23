    public class UserEntry: IDataErrorInfo
    {
        public string UserType{get;set;}
    
        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                if(propertyName=="UserType")
                {
                    // This is greatly simplified -- your validation may be different
                    if(UserType != "Patient" || UserType != "Doctor" || UserType != "Department")
                    {
                        return "Entry must be either Patient, Doctor, or Department.";
                    }
                }
                return null;
            }
        }
    
        string IDataErrorInfo.Error
        {
            get
            {
                return null; // You can implement this if you like
            }
        }
    }
