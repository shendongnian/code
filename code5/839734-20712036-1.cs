    public void Bind()
    {
        //Assign the datasource to GridView
        this.grdCart.DataSource = Get_Arealist();
        //Databind the grid 
        this.grdCart.DataBind();
    
    
        decimal a = 0, c = 0;
        for (int i = 0; i < grdCart.RowCount; i++)
        {
            a = Convert.ToDecimal(grdCart.Rows[i].Cells[3].Text.ToString());
            c += a; //storing total qty into variable 
        }
        Label2.Text = Convert.ToString(c);
    }
