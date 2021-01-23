    string select = "Select * FROM ivykiai WHERE `Ivikio diena` MOD Periodiskumas_d = 0 AND `Ivikio diena` > 0 AND `Ivikio diena` < `Dif dien`";
    using (MySqlCommand command = new MySqlCommand(select, cnn))
    {
        // execute the select query and store the results to list variable
        List<MyClass> list = new List<MyClass>();
        using (MySqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                MyClass record = new MyClass();
                record.Nuo = Convert.ToDateTime(reader["Nuo"]);
                record.IvikioDiena = Convert.ToInt32(reader["Ivikio diena"]);
                record.Periodiskumas_d = Convert.ToInt32(reader["Periodiskumas_d"]);
                record.Suma = Convert.ToInt32(reader["Suma"]);
                list.Add(record);
            }
        }
        // enumerate list and execute both the update queries
        foreach (var record in list)
        {
            db1 = (now - record.Nuo).TotalDays;
            MessageBox.Show(db1.ToString());
            db1 = db1 - record.IvikioDiena;
            MessageBox.Show(db1.ToString());
            b = Convert.ToInt32(db1) / record.Periodiskumas_d;
            MessageBox.Show(b.ToString());
            a =+ record.Suma;
            MessageBox.Show(a.ToString());
            a = a * b;
            MessageBox.Show(a.ToString());
            string prideti = "Update Lesos Set Grynieji=Grynieji + '"+ a +"'";
            MySqlCommand prideti_cmd = new MySqlCommand(prideti, cnn);
            string p = prideti_cmd.ExecuteNonQuery().ToString();
            string update = "UPDATE Ivikiai Set `Ivykio diena`+= '" + db1 + "'";
            MySqlCommand update_cmd = new MySqlCommand(update, cnn);
            string u = update_cmd.ExecuteNonQuery().ToString();
        }
    }
