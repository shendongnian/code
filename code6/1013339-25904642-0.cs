    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
         
     string id= gvCustomReports.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[0].ToString();
     Response.Redirect("MailsByOne.aspx?contactid="+id);
    }
