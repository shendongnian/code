    [WebMethod()]
    public static string Insert_OtherServices(string countVal)
    {
            dsJobCardTableAdapters.Select_OtherServiceTableAdapter dsother = new dsJobCardTableAdapters.Select_OtherServiceTableAdapter();
    
            string val = dsother.Insert_OtherService(countVal);
            return val;
    }
