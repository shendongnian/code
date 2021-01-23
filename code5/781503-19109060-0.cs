    Syntax : 
    public void RegisterClientScriptBlock(
    	Type type,
    	string key,
    	string script,
    	bool addScriptTags
    )
    
    Parameters
    
    type
        Type: System.Type
    
        The type of the client script to register. 
    
    key
        Type: System.String
    
        The key of the client script to register. 
    
    script
        Type: System.String
    
        The client script literal to register. 
    
    addScriptTags
        Type: System.Boolean
    
        A Boolean value indicating whether to add script tags.
    
      public void Page_Load(Object sender, EventArgs e)
      {
        // Define the name and type of the client scripts on the page.
        String csname1 = "PopupScript";
        String csname2 = "ButtonClickScript";
        Type cstype = this.GetType();
    
        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;
    
        // Check to see if the startup script is already registered.
        if (!cs.IsStartupScriptRegistered(cstype, csname1))
        {
          String cstext1 = "alert('Hello World');";
          cs.RegisterStartupScript(cstype, csname1, cstext1, true);
        }
    
        // Check to see if the client script is already registered.
        if (!cs.IsClientScriptBlockRegistered(cstype, csname2))
        {
          StringBuilder cstext2 = new StringBuilder();
          cstext2.Append("<script type=\"text/javascript\"> function DoClick() {");
          cstext2.Append("Form1.Message.value='Text from client script.'} </");
          cstext2.Append("script>");
          cs.RegisterClientScriptBlock(cstype, csname2, cstext2.ToString(), false);
        }
      }
