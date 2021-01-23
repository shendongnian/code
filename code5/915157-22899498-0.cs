                string MyConString = "SERVER=" + Config_Settings.ip + ";" + "DATABASE=" + Config_Settings.db + ";" + "UID=" + Config_Settings.user + ";" + "PASSWORD=" + Config_Settings.pw + ";";
                MySqlConnection connection = new MySqlConnection(MyConString);
                string command = "SHOW COLUMNS FROM t_string";
                MySqlDataAdapter da = new MySqlDataAdapter(command, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<MyModel> models = new List<MyModel>();
                foreach (DataRow row in dt.Rows)
                {
                    MyModel model = new MyModel
                    {
                        Name = (string)row[0]
                    };
                    models.Add(model);
                }
                bindingSource1.DataSource = models;
                comboBox1.DataSource = bindingSource1.DataSource;
                comboBox1.DisplayMember = "Languae";
                comboBox1.ValueMember = "Languae";
