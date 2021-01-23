    OleDbCommand command = new OleDbCommand("Insert into Employees (ID, Name, Last_name, Username, Password, E_mail, Address, administrator_rights) values(?, ?, ?, ?, ?, ?, ?, ?)",
                                            new OleDbConnection ("YourConnection"))
    {
        Parameters = { new OleDbParameter("ID", OleDbType.Integer),
                       new OleDbParameter("Name", OleDbType.VarWChar ),
                       new OleDbParameter("Last_name", OleDbType.VarWChar),
                       new OleDbParameter("Username", OleDbType.VarWChar),
                       new OleDbParameter("Password", OleDbType.VarWChar),
                       new OleDbParameter("E_mail", OleDbType.VarWChar),
                       new OleDbParameter("Address", OleDbType.VarWChar),
                       new OleDbParameter("administrator_rights", OleDbType.Boolean )}
    };
    private bool Update()
    {
        command.Parameters["ID"].Value = this.ID.Text;
        command.Parameters["Name"].Value = this.name.Text;
        command.Parameters["Last_name"].Value = this.lastName.Text;
        command.Parameters["Username"].Value = this.userName.Text;
        command.Parameters["Password"].Value = this.password.Text;
        command.Parameters["E_mail"].Value = this.eMail.Text;
        command.Parameters["Address"].Value = this.address.Text;
        command.Parameters["administrator_rights"].Value = checkBox1.Checked;
        var result =  command.ExecuteNonQuery();
        return result == 0 ? false : true;
    }
