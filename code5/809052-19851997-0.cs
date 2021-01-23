    protected void DropDownList1_Change(object sender, EventArgs e)
    {
      
            string pid = DropDownList1.SelectedItem.Text;
            HospNo.Text = pid.ToString();//Error in this line
        
    }
