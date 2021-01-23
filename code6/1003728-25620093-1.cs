    protected void btn_modify_Click(object sender, EventArgs e)
    {
          foreach (ListItem val in CheckBoxList.Items)
          {
              if (val.Checked)
               {
                   this.GridView1.Columns[0].Visible = false;
                                   .
                                   .
                                   .
               }
              else
               {
                   this.GridView1.Columns[0].Visible = true;
               }
          }
    }
