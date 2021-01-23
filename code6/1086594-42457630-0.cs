     public static string WriteHtmlToTempFile(string html)
     {
         var fileName = GetTempFileName("html");
         System.IO.File.WriteAllText(fileName, html);
         return fileName;
    
     }
     var strHtml = "<HTML> Hello World</HTML>";
     var file = Common.WriteHtmlToTempFile(strHtml);
     var wUri = new Uri(string.Format(@"file://{0}", file   ));
     webControl2.Source = wUri;
     
