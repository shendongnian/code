    <Query Kind="Program">
      <Reference>&lt;ProgramFilesX86&gt;\Microsoft Visual Studio 12.0\Visual Studio Tools for Office\PIA\Office15\Microsoft.Office.Interop.Outlook.dll</Reference>
      <Reference>&lt;ProgramFilesX86&gt;\Microsoft Visual Studio 12.0\Visual Studio Tools for Office\PIA\Office15\Microsoft.Office.Interop.OutlookViewCtl.dll</Reference>
      <Namespace>Microsoft.Office.Interop.Outlook</Namespace>
    </Query>
    void Main()
    {
        GetManagerDirectReports();
    }
    // Define other methods and classes here
    private void GetManagerDirectReports()
    {
        var app = new Microsoft.Office.Interop.Outlook.Application();
        AddressEntry currentUser = app.Session.CurrentUser.AddressEntry;
        if (currentUser.Type == "EX")
        {
            ExchangeUser manager = currentUser.GetExchangeUser().GetExchangeUserManager();
            manager.Dump();
            if (manager != null)
            {
                AddressEntries addrEntries = manager.GetDirectReports();
                if (addrEntries != null)
                {
                    foreach (AddressEntry addrEntry in addrEntries)
                    {
                        ExchangeUser exchUser = addrEntry.GetExchangeUser();
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Name: " + exchUser.Name);
                        sb.AppendLine("Title: " + exchUser.JobTitle);
                        sb.AppendLine("Department: " + exchUser.Department);
                        sb.AppendLine("Location: " + exchUser.OfficeLocation);
                        sb.Dump();
                    }
                }
            }
        }
    }
