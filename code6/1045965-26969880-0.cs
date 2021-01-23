    using System.Web.Services.WebMethod
    [WebMethod]
    public static string[] getTitles()
                {
                    SPListItemCollection obj = RAK.DAL.DAL.GetSPListItemCollection("", "Map", null, 0, true, true);
                    SPQuery query = new SPQuery();
    
                    string[] titles = new string[100];
                    int count = 0;
                    foreach (SPListItem item in obj)
                    {
                        titles[count]= item["Title"].ToString();
                        count++;
                    }
                    return titles;
                }
