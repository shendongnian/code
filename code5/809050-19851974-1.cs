    if (!IsPostBack)
    {
        // Check to see if the selected item of the drop down list is still around
        if(DropDownList1.SelectedItem != null)
        {
            if(!String.IsNullOrEmpty(DropDownList1.SelectedItem.Text)
            {
                HospNo.Text = DropDownList1.SelectedItem.Text;
            }
        }
    
        //other code
    }
