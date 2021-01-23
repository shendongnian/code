    protected void Page_Load(object sender, EventArgs e)
        {
            var fanceBoxDate = new DateTime(2013, 11, 20); //get date from CMS system
            if (DateTime.Today == fanceBoxDate)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "fancyBox", "var isFancybox = true", true);    
            }
        }
