    using System.Reflection;
    using System.Runtime.InteropServices;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using Microsoft.Office.Core;
    
    ...
    
    public static bool IsOutlookAddinEnabled(string addinName)
    {
        bool isEnabled = false;
    
        Outlook.Application outlookApp = null;
    
        if (System.Diagnostics.Process.GetProcessesByName("OUTLOOK").Length > 0)
        {
            outlookApp = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
        }
        else
        {
            outlookApp = new Outlook.Application();
            Outlook.NameSpace nameSpace = outlookApp.GetNamespace("MAPI");
            nameSpace.Logon("", "", Missing.Value, Missing.Value);
            nameSpace = null;
        }
    
        try
        {
            COMAddIn addin = outlookApp.COMAddIns.Item(addinName);
            isEnabled = addin.Connect;
        }
        catch { }
    
        return isEnabled;
    }
