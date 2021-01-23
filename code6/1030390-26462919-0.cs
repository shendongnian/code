     protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
          try
           {
              if (!string.IsNullOrEmpty(ddlCountry.SelectedItem.Text))
              {
                if (ddlCountry.SelectedItem.Text == "India")
                {                  
                }
                else 
                {                   
                }                
              }          
           }
           catch (System.Exception ex)
           {
             throw new MyException(" Message:" + ex.Message, ex.InnerException);
           }
    }
