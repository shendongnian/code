    protected void MainMenu_OnItemClick(object sender, RadMenuEventArgs e)
      {
                if (e.Item.Text == "About")
                {
    string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"; 
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);  
    
                }
      }
