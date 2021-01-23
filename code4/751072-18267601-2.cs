    [WebMethod (EnableSession=true)]
            public static void addSession(String hotelcode)
            {
                HttpContext.Current.Session.Add("hotelcode", hotelcode);
    
            }
