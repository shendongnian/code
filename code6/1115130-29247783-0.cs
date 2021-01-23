     private void Form1_Load(object sender, EventArgs e)
            {
                comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection combData = new AutoCompleteStringCollection();
                getData(combData);
                comboBox1.AutoCompleteCustomSource = combData;
            }
            private void getData(AutoCompleteStringCollection dataCollection)
            {
                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                connetionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\xxx.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
                string sql = "SELECT model FROM vehicle";
                connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                    adapter.Dispose();
                    command.Dispose();
                    connection.Close();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataCollection.Add(row[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not open connection ! ");
                }
            }
