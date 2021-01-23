    protected void Page_Load(object sender, EventArgs e)
            {
                //Bind your grid view
                GridView1.DataBind();
            }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                    int rowIndex = e.Row.RowIndex;
                   //First fetch your textboxes and labeles 
                    TextBox textBoxQ1 = GridView1.Rows[rowIndex].FindControl("Q1") as TextBox;
                    TextBox textBoxQ2 = GridView1.Rows[rowIndex].FindControl("Q2") as TextBox;
        
                    Label Label1 = GridView1.Rows[rowIndex].FindControl("Label1") as Label;
                    Label Label2 = GridView1.Rows[rowIndex].FindControl("Label2") as Label;
        
                    if (Window_name.Equals("Q2"))
                    {
                        //Set 'visiblity' to 'true' for those LABEL you want to show. Sample one below
                        Label2.Visible = false;
                        //Set 'visibilty' to 'false' for those TEXT BOXES you want to hide. Sample one below
                        textBoxQ2.Visible = false;
                    }
                }
