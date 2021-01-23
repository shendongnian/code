    private DataTable data = null;
    private int currentRecord = 0;
    protected void form_load(object sender, EventArgs e)
    {
         using(OleDbConnection con1 = new OleDbConnection(constr))
         using(OleDbCommand cmd = new OleDbCommand("select * from table", con1))
         {
             con1.Open();
             using(OleDbDataAdapter da = new OleDbDataAdapter(cmd))
             {
                 data = new DataTable();
                 da.Fill(data);
             }
             DisplayCurrentRecord();
        }
    }
    private void DisplayCurrentRecord()
    {
        label1.Text = String.Format("{0}", data.Rows[currentRecord][1]);
        RadioButton1.Text = String.Format("{0}", data.Rows[currentRecord][2]);
        RadioButton2.Text = String.Format("{0}", data.Rows[currentRecord][3]);
        RadioButton3.Text = String.Format("{0}", data.Rows[currentRecord][4]);
        RadioButton4.Text = String.Format("{0}", data.Rows[currentRecord][5]);
    }
    protected void btn_clk(object sender, EventArgs e)
    {
        if(currentRecord >= data.Rows.Count - 1)
            currentRecord = 0;
        else
            currentRecord++;
        DisplayCurrentRecord();
    }
