    public object GetHeaderInfo(string agentId, string headerName)
    {
        object headerInfo = 0;
    
        if (headerName == "flyer")
        {
            headerInfo = Service.GetFlierHeaderInfo(agentId);
        }
        if (headerName == "general")
        {
            headerInfo = Service.GetHeaderInfo(agentId);
        }
        return headerInfo;
    }
