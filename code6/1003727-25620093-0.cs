    protected void btn_modify_Click(object sender, EventArgs e)
    {
         int index = ((GridViewRow)((CheckBox)sender).Parent.Parent).RowIndex;
    
         foreach (ListItem val in CheckBoxList.Items)
          {
              if (val.Checked)
               {
                   this.GridView1.Columns[index ].Visible = false;
               }
              else
               {
                   this.GridView1.Columns[index ].Visible = true;
               }
          }
    }
