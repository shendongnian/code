    protected void EmpGridView_RowDataBound(object sender, GridViewRowEventArgs e)
      {
           if (e.Row.RowType == DataControlRowType.DataRow)
            { 
              // Create a label control  
              Label lbl = new Label();
              lbl.Text="MyDynamic Label";
              lbl.ID="lbl1"; // use ID values you prefer 
        
             // lets create one more control for example      
              LinkButton btnlink = new LinkButton();
              btnlink.Text = "Delete";
              btnlink.ID = "btnDelete";
              linkb.Click += new EventHandler(btnlink_Click);
            
            // add the controls to your placeholder inside <ItemTemplate>
            PlaceHolder phld = e.Row.FindControl("Placeholder1") as PlaceHolder;
            phld.Controls.Add(btnlink);
            phld.Controls.Add(lbl);
            //code to add the control to only a specific COLUMN/ Cell
            e.Row.Cells[1].Controls.Add(btnlink); // adding to 2nd Column
            // adding to last column..
            e.Row.Cells[EmpGridView.Columns.Count - 1].Controls.Add(btnlink);
                }
            }
