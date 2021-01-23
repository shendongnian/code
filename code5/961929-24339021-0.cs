        cm = new OleDbCommand("select usnam,paswd from signin where usnam = @a and paswd = @b", cn);
        cm.Parameters.AddWithValue("@usnam", textBox1.Text.ToString());
        cm.Parameters.AddWithValue("@paswd", textBox2.Text.ToString());
        string un;
        string pw;
        cn.Open();
        OleDbDataReader dr = cm.ExecuteReader();
        if (dr.Read())
        {
            new Form1().Show();
        }
        else
        {
            MessageBox.Show("Invalied Username or Password");
        }
