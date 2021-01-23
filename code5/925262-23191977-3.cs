    private void button1_Click(object sender, EventArgs e)
    {
       if(CheckDuplicateCustomer(Convert.ToIn32(CustId.Text)))
       {
             MessageBox.Show("Customer Already Exists with ID "+CustId.Text);
       }
       else
       {
         //your code to insert the customer into table
       } 
    }
