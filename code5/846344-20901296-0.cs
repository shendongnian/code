    using System.Globalization;
    using System.Threading;
    //...
    protected void Application_BeginRequest(Object sender, EventArgs e)
    {    
      CultureInfo newCulture = (CultureInfo) System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
      newCulture.DateTimeFormat.FullDateTimePattern = "dd/MMM/yyyy HH:mm:ss";
     newCulture.DateTimeFormat.DateSeparator = "-";
     Thread.CurrentThread.CurrentCulture = newCulture;
    }
  
