    PropertyInfo isreadonly = 
      typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
      "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
    // make collection editable
    isreadonly.SetValue(this.Request.QueryString, false, null);
    // remove
    this.Request.QueryString.Remove("editFlag");
