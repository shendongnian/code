       DataSet dsGrid = populate your grid here; //global variable
     protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    
     dsGrid.Tables[0].Rows[BankGrid.Rows[e.RowIndex].DataItemIndex].Delete();
     dsGrid.AcceptChanges();
     dsGrid.WriteXml(Server.MapPath("XMLFile.xml"));
     BindGridView();
    
    }
      protected void BindGridView()
               {
           GridView1.Datasource=dsGrid;
           Gridview1.DataBind();
                }
