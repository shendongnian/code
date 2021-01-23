    protected void Page_Load(object sender, EventArgs e)
    {
    
        if (!IsPostBack)
        {
            // Register JavaScript which will collect the value and assign to HiddenField and trigger a postback
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SetHiddenField", "SetHiddenField();", true); 
        }
        else 
        {
            //Also, I would add other checking to make sure that this is posted back by our script
            string ControlID = string.Empty;
            if (!String.IsNullOrEmpty(Request.Form["__EVENTTARGET"]))
            {
                ControlID = Request.Form["__EVENTTARGET"];
            }
            if (ControlID == HiddenField.ClientID) 
            { 
                //On postback do our operation
                string myVal = HiddenField.Value;
                //etc...
            }
        }
    
    }
