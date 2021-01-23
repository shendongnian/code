    public object GetHeaderInfo(string agentId, string headerName)
    {
        object headerInfo = null;
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
