                public void Post([FromBody]JToken value)
                {
                    var path = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data");
        
                    File.WriteAllText(path + @"/WriteJSON" + DateTime.Now.Ticks.ToString() + ".txt", value.ToString());
    
                    // write any code that you want to here
                    
                }
