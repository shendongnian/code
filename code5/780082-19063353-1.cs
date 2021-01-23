    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DX")
        {
            string FID = e.CommandArgument.ToString();
            var dt = GetData("select * from Personal_det where Fid='" + FID + "'");
            //and so on...
        }
    }
