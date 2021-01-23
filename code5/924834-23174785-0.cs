    public void comboboxes() {
        using (OracleConnection conn = new OracleConnection("Data Source=localhost;Persist Security Info=True;User ID=kursinis1;Password=1234;Unicode=True")) {
            try {
                conn.Open();
                //comboBox1.Items.Clear();
                DataSet dsetas1 = new DataSet();
                OracleDataAdapter data1 = new OracleDataAdapter("select aut_id, (aut_vardas || ' ' || aut_pavarde) AS autorius from autoriai", conn);
                data1.SelectCommand.CommandType = CommandType.Text;
                data1.Fill(dsetas1);
                //dsetas1.Dispose();
                //data1.Dispose();
                //conn.Close();
                comboBox1.DataSource = dsetas1.Tables[0];
                comboBox1.DisplayMember = "autorius";
                comboBox1.ValueMember = "aut_id";
            } catch (Exception ex) { MessageBox.Show("Can not open connection ! "); }
            finally {
                if (ConnectionState.Open == conn.State) conn.Close();
            }
        }
    }
