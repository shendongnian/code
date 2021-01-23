    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
         {
            DataSet1TableAdapters.TextBoxTableTableAdapter tx;
            tx = new DataSet1TableAdapters.TextBoxTableTableAdapter();
            DataTable dt = new DataTable();
            dt = tx.GetstudData(int.Parse(DropDownList1.SelectedValue));
            foreach (DataRow row in dt.Rows)
               {
               TextBox1.Text = (row["FirstName"].ToString());
               TextBox2.Text = (row["SecondName"].ToString());
               }
         }
