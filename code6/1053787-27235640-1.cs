        [WebMethod]
        public static string DoSomething()
        {
            if (Email.Send)
            {
                return "success";
            }
            return "not a success";
        }
