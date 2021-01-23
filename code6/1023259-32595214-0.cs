            fruits.AcceptChanges();
            fruits.Tables[0].Rows[0]["quantity"] =1111;
            MessageBox.Show(ds.Tables[0].Rows[0]["quantity"].ToString());
            DataSet changes = ds.GetChanges();
            if (changes != null)
            {
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Update(changes);
                fruits.AcceptChanges();
                MessageBox.Show("New value: " + ds.Tables[0].Rows[0]["quantity"]);
            }
            connection.Close();
