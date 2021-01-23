    using (var powershell = PowerShell.Create())
    {
       powershell.AddScript("Add-PsSnapin Microsoft.SharePoint.PowerShell");
       powershell.AddScript(string.Format("$web = Get-SPWeb {0}", webUrl));
       powershell.AddScript("$web.Lists");
       var psLists = powershell.Invoke();
       foreach (var psList in psLists)
       {
           powershell.Runspace.SessionStateProxy.SetVariable("list", psList);
           powershell.AddScript("$list.ContentTypes");
           var psContentTypes = powershell.Invoke();
           foreach (var psContentType in psContentTypes)
           {
              //var contentType = psContentType.BaseObject as SPContentType;
              //var name = contentType.Name;
              
              var type = psContentType.BaseObject.GetType();
              if (type.Name == "SPContentType")
              {
                  var contentTypeName = psContentType.Members["Name"].Value;
              }
           }
       }
    }
