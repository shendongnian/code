    protected void print_click(object sender,eventargs e)
    {
      //when i click this button i need to call javascript function
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script language="'javascript'">");
                sb.Append(@"example();");
                sb.Append(@"</script>");
         System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall1", sb.ToString(), false);
    }
    
