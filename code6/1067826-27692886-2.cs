     protected void ddlUserSelected_SelectedIndexChanged(object sender, EventArgs e)
      {
        for (int a = 1; a <= int.Parse(ddlUserSelected.SelectedItem.Text); a++)
        {
            TextBox txtDate = new TextBox();
            Label lbl = new Label();
            lbl.Text = "<br/>";
            txtDate.Width = 70;
            txtDate.CssClass = "tbl";
            txtDate.ID = "txtDate" + a;
            PlaceHolder1.Controls.Add(txtDate);
            PlaceHolder1.Controls.Add(lbl);
        }
      }
      protected void btnSave_Click(object sender, EventArgs e)
      {
        for (int a = 1; a <= int.Parse(ddlUserSelected.SelectedItem.Text); a++)
        {
            if(Request.Form.Get("txtDate" + a.ToString()) != null)
            {
                var str = Request.Form.Get("txtDate" + a.ToString());
            }        
        }
      }
