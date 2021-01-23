    protected void btnsub_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtdetails.Text != "")
            {
                lblsource.Text=lblsource.Text+ txtdetails.Text;
                txtdetails.Text = txtdetails.Text.Replace(System.Environment.NewLine, "<br>");
                maxid = g1.generate_max_reg_id("select max(id) from tbl_content");
                rows = g1.ExecDB("insert into tbl_content values(" + maxid + ",'" + txtdetails.Text.ToString() + string.Format("{0}<strong>MyName</strong>", lblsource.Text)+"')");
                txtdetails.Text = string.Empty;
             }
             if (rows > 0)
             {
                 ClientScript.RegisterStartupScript(typeof(Page), "AlertMessage", "alert('Successful!!!');window.location='textare_append.aspx';", true);
             }
         }
         catch (Exception ex)
         {
             Response.Write(ex.ToString());
         }
     }
