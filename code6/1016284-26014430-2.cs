    protected void mydrop_SelectedIndexChanged(object sender, EventArgs e)
    {
       string[] a = new string[] { test.SelectedItem.Text, test2.Text,};
       Session["dataForm"] = a;
       Response.Redirect("~/mypage.aspx");
    }
