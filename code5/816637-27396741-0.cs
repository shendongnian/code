    catch (WebException e)
    {
       string pageContent = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd().ToString();
       return pageContent;
    }
