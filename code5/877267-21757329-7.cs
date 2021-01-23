    foreach (
        SPWeb web in
            clientSiteCollection.AllWebs.Where(
                c =>
                c.AllProperties[Constants.WebProperties.General.WebTemplate] != null &&
                c.AllProperties[Constants.WebProperties.General.WebTemplate].ToString() ==
                Constants.WebTemplates.JobWebPropertyName).OrderByDescending(d => d.Created).SafeTake(5)
        )
    {
        try
        {
            if (!web.DoesUserHavePermissions(SPContext.Current.Web.CurrentUser.LoginName, SPBasePermissions.Open)) continue;
            SPList jobInfoListSp = web.Lists.TryGetList(Constants.Lists.JobInfoName);
            if (jobInfoListSp == null) continue;
            if (0 >= jobInfoListSp.Items.Count) continue;
            
            var value =
                new SPFieldUrlValue(
                    jobInfoListSp.Items[0][Constants.FieldNames.Job.iPowerLink].ToString());
    
            jobInfoList.Add(new JobInfo
            {
                JobName =
                    jobInfoListSp.Items[0][Constants.FieldNames.Job.JobName].ToString(),
                JobCode =
                    jobInfoListSp.Items[0][Constants.FieldNames.Job.JobCode].ToString(),
                IPowerLink = value.Url,
                JobWebsite = web.Url,
                IsConfidential =
                    HelperFunctions.ConvertToBoolean(
                        jobInfoListSp.Items[0][Constants.FieldNames.Job.Confidential]
                            .ToString())
            });
        }
        finally
        {
            web.Dispose();
        }
    }
