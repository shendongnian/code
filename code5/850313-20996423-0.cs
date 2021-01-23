    private void BindData()
    {
        string connectionString = "Server=localhost;" + 
               "Database=Northwind;Trusted_Connection=true";
        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlCommand myCommand = new SqlCommand("usp_GetProducts", 
                                               myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;
    
        myCommand.Parameters.AddWithValue("@startRowIndex", 
                                          currentPageNumber);
        myCommand.Parameters.AddWithValue("@maximumRows", PAGE_SIZE);
        myCommand.Parameters.Add("@totalRows", SqlDbType.Int, 4);
        myCommand.Parameters["@totalRows"].Direction = 
                           ParameterDirection.Output;
    
        SqlDataAdapter ad = new SqlDataAdapter(myCommand);
    
        DataSet ds = new DataSet();
        ad.Fill(ds);
    
        gvProducts.DataSource = ds;
        gvProducts.DataBind();
    
        // get the total rows 
        double totalRows = (int)myCommand.Parameters["@totalRows"].Value;
    
        lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();
    
        lblCurrentPage.Text = currentPageNumber.ToString(); 
    
        if (currentPageNumber == 1)
        {
            Btn_Previous.Enabled = false;
    
            if (Int32.Parse(lblTotalPages.Text) > 0)
            {
                Btn_Next.Enabled = true;
            }
            else
                Btn_Next.Enabled = false;
    
        }
    
        else
        {
            Btn_Previous.Enabled = true;
    
            if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
                Btn_Next.Enabled = false;
            else Btn_Next.Enabled = true; 
        }
    }
