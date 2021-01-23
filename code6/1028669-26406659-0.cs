     public virtual void SetProperty(string propertyName, object propertyValue)
        {
            
            if(String.IsNullOrEmpty(propertyName))
            {
                throw new Exception("Property name cannot be null or empty while setting value from quickbase. Make sure yor query to the API is returning a property name! [Filed Title:Label]");
            }
            else
            {
                try
                {
                    // Get the Type object corresponding to MyClass.
                    Type myType = typeof(BaseSetting);
                    // Get the PropertyInfo object by passing the property name.
                    PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                    if (myPropInfo != null)
                    {
                        this.GetType().GetProperty(propertyName).SetValue(this, propertyValue);
                    }
                    
                    
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("The property does not exist in our BaseSettings. PLease verify that it exist in the class design, or that the corrct field is being pulled form Quickbase. Error:" + e.Message);
                }
            }
        }
