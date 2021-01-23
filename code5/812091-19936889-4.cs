    public object GetHeaderInfo(string agentId, string headerName) //(string Mlsnums)
    {
       var headerInfo = 0;
       switch (headerName )
       {
        case "flyer":
        headerInfo = Service.GetFlierHeaderInfo(agentId);
       
        case "general":
        headerInfo  = Service.GetHeaderInfo(agentId);
       }
     return headerInfo ;
    }
