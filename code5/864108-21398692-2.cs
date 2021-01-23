        [WebMethod]
        public static List<string> GetDdlList()
        {
            //This can be your call to database. Hard-coded here for simplicity
            List<string> lst = new List<string>();
            lst.Add("aaa");
            lst.Add("bbb");
            return lst;
        }
