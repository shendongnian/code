            decimal CompraTotal2 = 0;
            MySqlConnection connection = new MySqlConnection(GlobalVars.mysql);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "QUERY";
            command.Parameters.AddWithValue("?GUID", Session["GUID"]);
            command.Parameters.AddWithValue("?Nombre", Session["previouslySelected"].ToString());
            MySqlDataReader reader = command.ExecuteReader();
            decimal Precio = 0;
            while (reader.Read())
            {
                // reader.GetString(0);
                Precio = Convert.ToDecimal(reader["Precio"]);
            }
            CompraTotal2 = Convert.ToDecimal(Session["CompraTotal"]);
            CompraTotal2 = Precio - CompraTotal2;
            Session["CompraTotal"] = CompraTotal2;
        }
        if (CheckBoxList1.SelectedIndex != -1)
        {
            decimal CompraTotal = 0;
            MySqlConnection connection = new MySqlConnection(GlobalVars.mysql);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "QUERY";
            command.Parameters.AddWithValue("?GUID", Session["GUID"]);
            command.Parameters.AddWithValue("?Nombre", CheckBoxList1.SelectedValue);
            MySqlDataReader reader = command.ExecuteReader();
            decimal Precio = 0;
            int i = 0;
            while (reader.Read())
            {
                // reader.GetString(0);
                Precio = Convert.ToDecimal(reader["Precio"]);
            }
            CompraTotal = Convert.ToDecimal(Session["CompraTotal"]);
            CompraTotal = CompraTotal + Precio;
            Session["CompraTotal"] = CompraTotal;
        }
        Session["previouslySelected"] = CheckBoxList1.SelectedIndex;
        Label3.Text = Convert.ToString(Session["CompraTotal"]);
        }
