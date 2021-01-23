        void Registration_Load(object sender, EventArgs e)
        {
            SystemManager.ClearTextBoxes(this.Controls);
            if (SystemManager.CheckType("Administrator") != true)
            {
                this.comboBox1.Items.Add("Administrator");
            }
            this.comboBox1.Items.Add("Member");
            this.comboBox1.SelectedIndex = 0;
            SystemManager._isCheckedDisplayName = false;
            _isCheckedEmail = false;
            this.button1.Enabled = false;
            this.button4.Enabled = false;
        }
    
           public static bool CheckType(string _value1)
            {
                using (OleDbConnection connection = new OleDbConnection(SystemManager.connectionString))
                {
                    string query = "SELECT COUNT(*) FROM [Member] WHERE [UserType] = @UserType";
    
                    connection.Open();
    
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@UserType", OleDbType.VarChar);
                        command.Parameters["@UserType"].Value = _value1;
    
                        _count = (int)command.ExecuteScalar();
    
                        connection.Close();
                    }
    
                }
    
                return _count > 0;
            }
