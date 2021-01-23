     var webUri = new Uri("http://contoso.sharepoint.com");
     string sourceUrl = @"C:\Documents\SharePoint User Guide.docx";
     string destinationUrl = webUri + "/documents/SharePoint User Guide 2013.docx";
     var fieldInfo = new FieldInformation();
     FieldInformation[] fieldInfos = { fieldInfo };
     CopyResult[] result;
     using (var proxyCopy = new Copy())
     {
          proxyCopy.Url = webUri + "/_vti_bin/Copy.asmx";
          proxyCopy.Credentials= new NetworkCredential(userName, password, domain);
          var fileContent = System.IO.File.ReadAllBytes(sourceUrl);
          proxyCopy.CopyIntoItems(sourceUrl, new[] { destinationUrl }, fieldInfos, fileContent, out result);
      }
 
 
