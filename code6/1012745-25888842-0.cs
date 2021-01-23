    SPFieldUserValue spuserFieldValue = (SPFieldUserValue)spuserField.GetFieldValue(item["Users"].ToString());
    //Tries to get SPUser
    if (spuserFieldValue.User != null)
    {
       SPUser user = userFieldValue.User;
    }
    //if the field contain group
    else
    {
      SPGroup group = web.SiteGroups.GetByID(spuserFieldValue.LookupId);
    }
