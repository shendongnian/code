     protected void UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            String value;
            if(Session["Value"] != null)
            {
                 value = Session["Value"].ToString();
            }
            else
            {
                 value = DropDownList1.SelectedItem.Text;
            } 
            //rest of your code
        }
