        [WebMethod]
        public static string DoSomething(string id)
        {
            var docs = SqlHelper.SelectAllByInvoiceId(id);
            if (docs.Count > 0)
            {
                return "exists";
            }
            return "does not exist";
        }
