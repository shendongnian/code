    protected void Page_Load(object sender, EventArgs e)
        {         
           if (autoOpenSSO == true)
           {
               ccdetails_Click(this, null);
           }
        }
        protected void ccdetails_Click(object sender, EventArgs e)
        {
            ClientScriptManager cs = Page.ClientScript;
            try
            {                
                string link = getSSOlink(ah1.InstitutionUserID, cardnumber).Trim();
                string s = "var popupWindow = window.open('" + link + "','_blank', 'width=980,height=600,resizable=yes');";
                string t = "window.location.replace('" + redirectAddress + "')";
                if (redirectUser == true)
                {
                    s = s + t;
                }
                cs.RegisterStartupScript(this.GetType(), "PopupScript", s, true);
                                
            }
            catch (Exception se)
            {
                LogSystem.LogInfo("Access issue - " + se.ToString());
                
            }
        }
