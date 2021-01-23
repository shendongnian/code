    if (!IsPostBack)
    {
        
    
       DropDownList1.AutoPostBack= true;
        string pid = DropDownList1.SelectedItem.Text;
        HospNo.Text = pid.ToString();//Error in this line
        //other code
    }
 }
