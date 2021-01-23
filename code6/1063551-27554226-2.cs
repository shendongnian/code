    private void btnAdd_Click(object sender, EventArgs e)
    {
        string articleId = cmbArticle.Text;
        string productDescription = txtDesc.Text;
        string type = txtType.Text;
        string materialType = txtMaterial.Text;
        string size = cmbSizes.Text;
        string quantity = txtQuantity.Text;
    
        try
        {
            DataRow dr = dt.NewRow();
            //addrows
            dr["Article"] = articleId;
            dr["Description"] = productDescription;
            dr["type"] = type;
            dr["Material"] = materialType;
            dr["Size"] = size;
            dr["Quantity"] = quantity;
            dt.Rows.Add(dr);
            dgvView.DataSource = dt;
        }
        catch (Exception ex)
        {
    
        }
    }
