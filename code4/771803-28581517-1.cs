    string sourceUrl = "https://contoso.sharepoint.com/Documents/SharePoint User Guide.docx";
    string destinationUrl = "https://contoso.sharepoint.com/Documents/SharePoint User Guide 2013.docx";
    FieldInformation[] fieldInfos;
    CopyResult[] result;
    byte[] fileContent;
    using(var proxyCopy = new Copy())
    {
         proxyCopy.Url = webUri + "/_vti_bin/Copy.asmx";
         proxyCopy.CookieContainer = GetAuthCookies(webUri, userName, password);
         proxyCopy.Credentials = new NetworkCredential(userName, password);
         proxyCopy.GetItem(sourceUrl,out fieldInfos,out fileContent);
         proxyCopy.CopyIntoItems(sourceUrl,new []{ destinationUrl}, fieldInfos, fileContent, out result);
     }
