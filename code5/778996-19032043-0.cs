    private void Validate(object sender, RoutedEventArgs e)
        {
          		
        using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\\Users\\Baladi\\documents\\visual studio 2012\\Projects\\CalUnderFoot\\CalUnderFoot\\UserPerm.mdb"))
        {
            OleDbCommand command = new OleDbCommand("select * from UserPermT where EmpEmail='"+EmpEmail.Text+"' and EmpPIN='"+EmpPIN.PasswordChar+"'", connection);
            connection.Open();
            OleDbDataReader dr= command.ExecuteReader();
    
            if (dr.Read())
            {
                MessageBox.Show("success");
            }
    
            else
            {
                MessageBox.Show("fail");
            }
            dr.Close();
        }
        }
