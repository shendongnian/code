    int rowsAffected = 0;
    try
    {
        Dictionary<string, object>() params = new Dictionary(string, object>();
        params.Add("@p_name", txtProdName.Text);
        params.Add("@p_desc", txtProdDesc.Text);
        params.Add("@sdate", StartDatePicker.Value.Date);
        params.Add("@edate", EndDatePicker.Value.Date);
        params.Add("@filenum", txtBoxFileNum.Text);
        string sql = "insert into product_details" +      
                     "(prod_name,prod_desc,prod_status,"+
                     "start_date,end_date,ref_num,ror) "+
                     "values(@p_name,@p_desc,@status,@sdate,@edate,@filenum,@ror)";
  
       rowsAffected = SqlHelper.InsertUpdate(connectionString, sql, params);
    }
    catch (Exception ex)
    {
       // Do something with the error;
    }
