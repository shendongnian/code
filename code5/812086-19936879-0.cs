     public object GetHeaderInfo(string agentId, string headerName) //(string Mlsnums)
     {
         object headerinfo;
         if (headerName == "flyer")
         {
             headerInfo = Service.GetFlierHeaderInfo(agentId);
             // headerinfo is of type Flier object
         }
         if (headerName == "general")
         {
             headerInfo = Service.GetHeaderInfo(agentId);
             // headerinfo is of type report object
         }
             return headerInfo ?? 0;
     }
