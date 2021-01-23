    public static void UploadFile(Uri targeUri, ICredentials credentials, string fileName)
    {
         using (var client = new WebClient())
         {
             client.Credentials = credentials;
             //client.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
             var targetFileUri = targeUri + "/" + Path.GetFileName(fileName);
             client.UploadFile(targetFileUri, "PUT", fileName);      
         }
     }
