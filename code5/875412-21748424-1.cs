     /// <summary>
     /// //Constructs the url to send the get request to.
     /// </summary>
     /// <param name="hostname">the hostname </param>
     /// <param name="ip">the ipaddress</param>
     /// <returns>The complete String</returns>
     private string BuildUrl(String hostname, String ip)
     {
        return BaseUrl + "hostname=" + hostname + "&myip=" + ip;
     }
