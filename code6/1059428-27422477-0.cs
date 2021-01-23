     while (!process.HasExited)
      {
        try
        {
          outlookObj = (Outlook.Application)Marshal.GetActiveObject("Outlook.Application");
          break;
        }
        catch
        {
          outlookObj = null;
        }
        System.Threading.Thread.Sleep(10);
      }
