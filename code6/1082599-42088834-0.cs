        //NameSpace    
        using System.Reflection;
        //Definition
        bool IsAnyNullOrEmpty(object myObject)
        {
            foreach(PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if(pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if(string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //Call
        bool flag = IsAnyNullOrEmpty(objCampaign.Account);
