        [WebMethod]
        public static void ClearDataTable()
        {
           
            HttpContext.Current.Session["datatable"] = null;
        }
