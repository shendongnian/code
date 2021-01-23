    public virtual string Text
    {
      get
      {
        string item = (string)this.ViewState["Text"];
        if (item != null)
        {
          return item;
        }
    
        return string.Empty;
      }
      set
      {
        this.ViewState["Text"] = value;
      }
    }
