    private const string _select_placeholder = "Select * from {0} where {1} like '%{1}%'";
    void btnCategory_Click (object sender, EventArgs e)
    {
        string sql= string.Format(_select_placeholder, "Category", "Category_Name", txtCategoty.Text.Trim());
        Search(sql);
    }
    void btnDescription_Click (object sender, EventArgs e)
    {
        string sql= string.Format(_select_placeholder, "Product", "Description", txtDescription.Text.Trim());
        Search(sql);
    }
    void btnManufacturer_Click (object sender, EventArgs e)
    {
        string sql= string.Format(_select_placeholder, "Manufacturer", "Manufacturer_Name", txtManufacturer.Text.Trim());
        Search(sql);
    }
    // Now, with cost, it is a little bit different thing. 
    // Usually, you search for range when it comes to digits. 
    // YOu can still search it using 'LIKE'. But this is not going to give you results that make sense. 
    // Here I show you what IS going to make sense.
    void btnProduct_Click (object sender, EventArgs e)
    {
        bool hasWhere;
        string sql = "Select * from Product";
        if (txtProductCostMin.Text.Trim() != string.Empty)
        {
            sql += " WHERE ";
            hasWhere = true;
            sql += "Product_cost >= " + txtProductCostMin.Text.Trim();
        }
        if (txtProductCostMax.Text.Trim() != string.Empty)
        {
            if (!hasWhere) 
                sql += " WHERE ";
            else
                sql += " AND ";
            
            sql += "Product_cost <= " + txtProductCostMax.Text.Trim();
        }
        Search(sql);
    }
    void Search (string sql)
    {
        // use your sql here to fill the grid, etc.
    }
