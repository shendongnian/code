    while (reader2.Read())
    {                                               
        for (int i = 0; i < reader2.FieldCount; i++)
        {
            string fieldname = reader2.GetName(i);
            y = fieldname.Length;
            if (fieldname != "Maand" && fieldname != "Uitgaven Id")
            {
                decimal euro_amount = reader.IsDbNull(i) ? 0m : reader2.GetDecimal(i);
                ListBox2_add.Items.Add(fieldname + "€".PadLeft(31 - y) + euro_amount.ToString("0.00", CultureInfo.CreateSpecificCulture("nl-NL")));
                comboBox1.Items.Add(fieldname);
                totaal_uitgaven += euro_amount;
            }
        }
    }
