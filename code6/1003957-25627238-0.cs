    public string ItemLanguage
    {
      get
      {
        return this.GetViewStateString("ItemLanguage");
      }
      set
      {
        Assert.ArgumentNotNull((object) value, "value");
        this.SetViewStateString("ItemLanguage", value);
      }
    }
