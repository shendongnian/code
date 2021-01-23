    [WebMethod]
            [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
            public void GetData(string login)
            {
                    
                // when the amount of data return is huge
                var serializer = new JavaScriptSerializer();
    
                // we need to do this.
                serializer.MaxJsonLength = Int32.MaxValue;
    
   
                var result = serializer.Serialize(service.GetData(login));
    
                   
                Context.Response.Write(result);
            }
