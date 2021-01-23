    private void textBox1_Leave(object sender, EventArgs e)
        {
            //Put the value to be checked with the Database in a Variable.
            var valueToCheck = textBox1.Text;
            //Create connection with the database.
            var sqlConn = new SqlConnection("Connection String to Database");
            //Create dataset instance to fill with the return results from the Database.
            var ds = new DataSet();
            //Create SqlCommand to be execute on the database.
            var cmd = new SqlCommand("SELECT * FROM TABLE WHERE 'field to be checked' = " + valueToCheck, sqlConn);
            //Create SqlDataAdapter
            var da = new SqlDataAdapter(cmd);
            ds.Clear();
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                //do you stuff here.
            }
        }
