    protected void results_BtnClick(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "del")
                    {
    
                        int id = Convert.ToInt32(e.CommandArgument);
                        int primaryID = Convert.ToInt32(results.DataKeys[id].Value);
    
                    ....Do Delete....
                    }
            }
