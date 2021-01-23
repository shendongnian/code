    [WebMethod()]
    public object getData()
    {
       List<string> dbdata = new List<string>();
       dbdata.Add("Vikas,200");
       dbdata.Add("Sumit,120");
       dbdata.Add("Rakesh,200");
       dbdata.Add("Shivam,500");
       dbdata.Add("Kapil,234");
       dbdata.Add("Rana,104");
       return JsonConvert.SerializeObject(dbdata);
    }
