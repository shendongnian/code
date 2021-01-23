    using (var activityInfoContext = new ActivityInfoContext())
    {
        var activityInfoList = activityInfoContext.ActivityInfo.Where(a => a.Activity == "System Forecast" && a.SiteID == SiteID).ToList();
        for (var i = 0; i < activityInfoList.Count; i++)
        {
            activityInfo[i].Value = aPRF[i];
        }
        activityInfoContext.SaveChanges();
    }
