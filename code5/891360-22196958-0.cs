    string formID = "{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}";
    DataUri uri = new DataUri(new ID(formID));
    Sitecore.Data.Items.Item formItem = Sitecore.Context.Database.GetItem(uri);
    
    // if the item exists, run through all the known fields and add the values from the customerinfo into them.
    if (formItem != null)
    {
       List<AdaptedControlResult> acrList = new List<AdaptedControlResult>();
       Sitecore.Data.Items.Item[] fieldItems = formItem.Axes.GetDescendants();
    
       foreach (Sitecore.Data.Items.Item fieldItem in fieldItems) //.Where(x => x.TemplateName == "Field"))
       {
          if (fieldItem.Name == "E-mail")
          {
             acrList.Add(new AdaptedControlResult(new ControlResult(fieldItem.Name, System.Web.HttpUtility.UrlDecode(customerInfo.Email), string.Empty) { FieldID = fieldItem.ID.ToString(), FieldName = fieldItem.Name, Value = System.Web.HttpUtility.UrlDecode(customerInfo.Email) }, true));
             continue;
          }
    
       // same for all other fields.
       }
    
       // save data
       if (acrList.Count > 0)
       {
          AdaptedResultList arl = new AdaptedResultList(acrList);
    
          try
          {
             Sitecore.Forms.Data.DataManager.InsertForm(formItem.ID, arl, Sitecore.Data.ID.NewID, null);
          }
          catch (Exception ex)
          {
             // Log data here
          }
       }
    }
