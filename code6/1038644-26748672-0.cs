    try
            {
                string ConnectionString = "User ID=*****;Password=*******;" +
                    "Database=C:\\Users\\marqu_000\\Documents\\WindowsFormsApplication13\\Sistema.GDB;" +
                    "DataSource=localhost";
                FbConnection addDetailsConnection = new FbConnection(ConnectionString);
                addDetailsConnection.Open();
                string SQLCommandText = "select * from LOGIN where USERNAME=@username and PASSWORD=@password";
                FbCommand addDetailsCommand = new FbCommand(SQLCommandText, addDetailsConnection);
                addDetailsCommand.Parameters.Add("@username", FbDbType.VarChar, 15).Value = userName.Text;
                addDetailsCommand.Parameters.Add("@password", FbDbType.VarChar, 15).Value = userPassword.Text;
                FbDataReader reader = addDetailsCommand.ExecuteReader();
                if (reader.Read())
                {
                    this.Visible = false;
                    MessageBox.Show("Login Successful!");
                    MainWin MWin = new MainWin();
                    MWin.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
