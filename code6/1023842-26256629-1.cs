    string fileName = "Test.ics";
    InternetCalendaring.ICSBuilder icsbBuilder = new InternetCalendaring.ICSBuilder(vecVEvents);
    sRes = icsbBuilder.ICSBuildProcess();
    byte[] Buffer = Encoding.Unicode.GetBytes(sRes);
    System.Web.HttpContext.Current.Response.AddHeader("content-type", "text/Calendar");
    System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
    System.Web.HttpContext.Current.Response.BinaryWrite(Buffer);
    //System.Web.HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.End();
