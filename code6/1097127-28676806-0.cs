         SqlCommand command1 = null;
        if (!string.IsNullOrWhiteSpace(txtId.Text))
        {
           command1 = new SqlCommand("SELECT * FROM ContactsList WHERE ID = @id");
           command1.Parameters.AddWithValue("@id", txtId.Text);
        }
        else
        {
           command1 = new SqlCommand("SELECT * FROM ContactsList ");
        }
        command1.Connection = connection;
        command1.CommandType = CommandType.Text;
