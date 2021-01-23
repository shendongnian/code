    protected void btnRefresDS_Click(object sender, EventArgs e)
    {
        try
        { 
            if (Session["EditObjectVar"] != null)
            {
                gv.DataSource = CurrentDS;
                gv.DataBind();
                Session.Remove("EditObjectVar");
            }
        }
        catch (Exception ee)
        {
            MyPage.Log(ee.StackTrace);
            MyPage.Log(ee.Message);
        }
    }
