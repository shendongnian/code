       [WebMethod]
        public static string AddClient(string ClientName)
            {
            string message;
            Class.DB.AddClient(ClientName, out message);            
    
            return message;
        
        }
