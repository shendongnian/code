    var maskedRequest = "";
    var qs = HttpUtility.ParseQueryString(request);
    foreach (string item in qs.AllKeys)
    {
       if (item != "cardnumber")
       {
           maskedRequest = maskedRequest + item + "=" + qs.Get(item) + "&";
       }
       else
       {
           maskedRequest = maskedRequest + item + "=" + string.Format("XXXX-XXXX-XXXX-{0}", qs.Get(item).Substring(12, 4)) + "&";
        }
    }
 
    maskedRequest = maskedRequest.Remove(maskedRequest.Length - 1)
