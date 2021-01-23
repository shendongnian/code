    //pre-render code as given below, 
    protected void Page_PreRender(object sender, EventArgs e)
    {
       try
         {
           TextBox txtindex = (TextBox)RptTask.Items[Nextindex].FindControl("TxtDuration");
           txtindex.Focus();
         }
       catch(Exception ee)
        {
        }
    } 
