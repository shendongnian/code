    MastersClient ProdType = new MastersClient();
    DataSet ds = ProdType.GetProductType();
    DataRow[] drProduct = ds.Tables[0].Select("ProductTypeCode ='" + txtProductTypeCode.Value+"'")
    if(drProduct.Length>0)
    {
       if(drProduct[0]["column name"].ToString()=="21")
       {
           // your code to do based on the condition
       }
    }
