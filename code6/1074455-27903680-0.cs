    protected override void OnPreRender(EventArgs e)
    {
      base.OnPreRender(e);
      if (!IsPostBack) 
      {
          Session.Add(Settings.LanguageParameters.LanguageParams, "English");
      }
      string language = Session["LanguageParams"].ToString();
      if (language == "English")
      {
          englishTable.Style.Add("display", "normal");
          frenchTable.Style.Add("display", "none");   
       }
       else
       {
           frenchTable.Style.Add("display", "normal");
           englishTable.Style.Add("display", "none");
       }
    }
