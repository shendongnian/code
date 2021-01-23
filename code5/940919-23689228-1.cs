    [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Object GetLatest()
            {
                Object obj= new Object ();
                obj.FirstName = "Dave";
                obj.LastName = "Ward";
         return obj;
        }
