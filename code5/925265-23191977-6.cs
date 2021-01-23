    private void button1_Click(object sender, EventArgs e)
    {
       int custid=Convert.ToInt32(CustID.Text);
       int contact=Contact.Text;
       int email=Email.Text;
       if(CheckDuplicateCustomer(custid,contact,email))
       {
             MessageBox.Show("Customer Already Exists with ID "+CustId.Text);
       }
       else
       {
         //your code to insert the customer into table
       } 
    }
