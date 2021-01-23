    protected void Page_Load(object sender, EventArgs e)
     {
              if (!Page.IsPostBack)
              {
                 BindControl();
                 frDownloadFiles.Attributes.Add("src", "../DownloadDataPackFiles.aspx?DataPackageID=" + CurrentDataPackages.Id.ToString());
                 ClientScriptManager cs = Page.ClientScript;
                 cs.RegisterStartupScript(this.GetType(),"RegisterScript" ,"RegisterScript();");
  
             }
    }
