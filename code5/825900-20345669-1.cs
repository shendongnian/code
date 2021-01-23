    private void ClearTextBox() 
    {
        txtsrno.Text = "";
        txtname.Text = "";
        txtaddress.Text = "";
        txtcontact.Text = "";
        txtamount.Text = "";
        txtemail.Text = "";      
    }
    
    private void btnadd_Click(object sender, EventArgs e)
    {
        try
        {
            srno = Convert.ToInt32(txtsrno.Text);
            Name = txtname.Text;
            address = txtaddress.Text;
            contactno = Convert.ToInt32(txtcontact.Text);
            amount = Convert.ToDouble(txtamount.Text);
            Emailid = txtemail.Text;
    
            DataRow dr = dt.NewRow();
            dr[0] = srno;
            dr[1] = Name;
            dr[2] = address;
            dr[3] = contactno;
            dr[4] = amount;
            dr[5] = Emailid;
    
            dt.Rows.Add(dr);
    
            dt.AcceptChanges();
            grd.DataSource = dt;
    
            ClearTextBox();
        }
        catch (Exception ex) { /*Handle Exception*/ } 
    }
