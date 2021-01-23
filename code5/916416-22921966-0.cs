    foreach (var notifyTemplate in notifyList)
                {
                    var value = string.Empty;
                    try
                    {
                       value  = notifyTemplate.Value.Invoke(user);
                    }
                    catch (Exception ex)
                    {
                        
                        //log error
                    }
    
                    var theVlaue = value;
            }
