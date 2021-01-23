    public object GetHeaderInfo(string agentId, string headerName) //(string Mlsnums)
    {
       switch (headerName )
       {
        case "flyer":
        return Service.GetFlierHeaderInfo(agentId);
       
        case "general":
        return Service.GetHeaderInfo(agentId);
       
        default:
        return 0;
      }
    }
