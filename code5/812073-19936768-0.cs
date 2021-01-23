    public object GetHeaderInfo(string agentId, string headerName) //(string Mlsnums)
    {
      var headerInfo = 0;
      if (headerName == "flyer")
      {
          headerInfo = Service.GetFlierHeaderInfo(agentId);
      }
      else if (headerName == "general")
      {
         headerInfo = Service.GetHeaderInfo(agentId);
      }
      return headerInfo;
    }
