      protected void ASPxGridView1_CustomColumnDisplayText(object sender, 
       ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Column1")
            {
                Label1.Text = e.Value.ToString();
            }
 
            if (e.Column.FieldName == "Column2")
            {
                Label2.Text = e.Value.ToString();
            }
           . 
        
           .
       
           if (e.Column.FieldName == "Column12")
            {
                Label12.Text = e.Value.ToString();
            }
           
        }
