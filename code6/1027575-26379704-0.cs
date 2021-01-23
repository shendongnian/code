    static ServiceController GetServiceControllerByPId(int processId)
    {
        string serviceName = "";
        string qry = "SELECT NAME FROM WIN32_SERVICE WHERE PROCESSID = " + processId.ToString();
        System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(qry);
        System.Management.ManagementObjectCollection mngntObjs = searcher.Get();
        foreach (System.Management.ManagementObject mngntObj in mngntObjs)
        {
            serviceName = (string)mngntObj["NAME"];
        }
        if (serviceName == "")
        {
            return null;
        }
        return System.ServiceProcess.ServiceController.GetServices().FirstOrDefault(x => x.ServiceName == serviceName);
    }
