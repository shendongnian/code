     protected void submit_Click(object sender, EventArgs e)
     {
          string name = txtFirstName.Text.Trim();
          Session["name"] = name;
          Response.Redirect("PageTwo.aspx");
     }
