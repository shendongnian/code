    HttpClientCertificate theHttpCertificate = HttpContext.Current.Request.ClientCertificate; 
    // split the subject into its parts
    string[] subjectArray = theHttpCertificate.Subject.Split(',');
    string[] nameParts;
    string CN = string.Empty;
    string firstName = string.Empty;
    string lastName = string.Empty;
    foreach (string item in subjectArray)
    {
        string[] oneItem = item.Split('=');
        // Split the Subject CN information
        if (oneItem[0].Trim() == "CN")
        {
           CN = oneItem[1];
           if (CN.IndexOf(".") > 0)
           {// Split the name information
               nameParts = CN.Split('.');
               lastName = nameParts[0];
               firstName = nameParts[1];
            }
        }
    }
   
