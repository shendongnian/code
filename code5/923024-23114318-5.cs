    //Method to get the hidden value from the master page, if the master page is a sub master page
    private string GetHiddenValue()
    {
       if (this.Master is SubMasterPage)
       {
          string value = (this.Master as SubMasterPage).HiddenValue;
          return value;
       }
       else
       {
          return string.Empty;
       }
    }
