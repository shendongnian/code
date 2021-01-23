    Form1 frm1 = new Form1();
    private void button_Click(object sender, EventArgs e)
    {
        dgvProducts.DataSource = frm1.ReadFromFile(tbCustomerID.Text);  <-- pass customer id       
    }
    public DataTable ReadFromFile(String customerId)
    {            
        //Read the data from text file
        string[] textData = File.ReadAllLines("MyTextFile.txt");
        string[] headers = textData[0].Split(',');
        //Create and populate DataTable
        DataTable dataTable1 = new DataTable();
        foreach (string header in headers)
            dataTable1.Columns.Add(header, typeof(string), null);
        for (int i = 1; i < textData.Length; i++)
           if textData[i].Split(',')[2].ToString() == customerId <-- add the row only if customer Id matches
             dataTable1.Rows.Add(textData[i].Split(','));            
        return dataTable1;
    }
