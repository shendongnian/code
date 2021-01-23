    public void Main()
    {
        Variables varCollection = null;
    
        Dts.VariableDispenser.LockForRead("User::RemoteUri");
        Dts.VariableDispenser.LockForRead("User::LocalFolder");
        Dts.VariableDispenser.GetVariables(ref varCollection);
    
        System.Net.WebClient myWebClient = new System.Net.WebClient();
        string webResource = varCollection["User::RemoteUri"].Value.ToString();
        string fileName = varCollection["User::LocalFolder"].Value.ToString() + webResource.Substring(webResource.LastIndexOf('/') + 1);
        myWebClient.DownloadFile(webResource, fileName);
    
        Dts.TaskResult = (int)ScriptResults.Success;
    }
