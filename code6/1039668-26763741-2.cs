    String employeeInfo = "";
    try
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://example.com/subsub.aspx?instprod=xxx&vabid=emailaddress");
        using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse()) //Error occurs here. 403 Forbidden
        {
            Uri myUri = new Uri(webResponse.ResponseUri.ToString());
            String queryParamerter = myUri.Query;
            employeeInfo = HttpUtility.ParseQueryString(queryParamerter).Get("vres");
            if (employeeInfo != "N/A")
            {
                return employeeInfo;
            }
            else
            {
                employeeInfo = "0";
                return employeeInfo;
            }
        }
    }
    catch (WebException ex)
    {
        HttpWebResponse response = ex.Response as HttpWebResponse;
        if(response.StatusCode != HttpStatusCode.Forbidden)
        {
            throw;
        }
        Uri myUri = new Uri(response.ResponseUri.ToString());
        String queryParamerter = myUri.Query;
        employeeInfo = HttpUtility.ParseQueryString(queryParamerter).Get("vres");
        if (employeeInfo != "N/A")
        {
            return employeeInfo;
        }
        else
        {
            employeeInfo = "0";
            return employeeInfo;
        }  
    }   
   
