    using System.Linq;
    using Microsoft.SharePoint.Linq;
    MyDataContext dc = new MyDataContext("http://localhost");
    var varUserActivity = (from item in dc.UserActivityList
                           orderby item.UsernameName.ToString().Substring(item.UsernameName.ToString().IndexOf('#') + 1, 1).ToLower().Replace("domain\\", "") ascending
                           select new { letter = item.UsernameName.ToString().Substring(item.UsernameName.ToString().IndexOf('#') + 1, 1).ToLower().Replace("domain\\", "") }).Distinct();
    
    foreach (var uaitem in varUserActivity)
    {
        this.Controls.Add(new LiteralControl(uaitem.letter + "<br>"));
    }
