    using Citrix.Common.Sdk;
    using Citrix.XenApp.Sdk;
    using Citrix.XenApp.Commands;
    using Citrix.Management.Automation;
        private void logoffUser(string strUser)
        {
            GetXASessionByFarm sessions = new GetXASessionByFarm(true);
            
            foreach (XASession session in CitrixRunspaceFactory.DefaultRunspace.ExecuteCommand(sessions))
            {
                if (session.AccountName.ToLower() == objWINSDomainName + "\\" + strUser)
                {
                    var cmd = new StopXASessionByObject(new[] { session });
                    CitrixRunspaceFactory.DefaultRunspace.ExecuteCommand(cmd);
                }
            }
        }
