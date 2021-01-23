    protected void ASPxGridView1_CustomColumnDisplayText(object sender,  
     ASPxGridViewColumnDisplayTextEventArgs e)
    {
        if (e.Column.FieldName == "Column1")
        {
            int a= Convert.ToInt32(e.Value).ToString();
        }
        if (e.Column.FieldName == "Column2")
        {
            string b= e.Value.ToString();
        }
