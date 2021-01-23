    comboBox1.Items.Clear(); //add this statetement before adding items
    comboBox2.Items.Clear(); //add this statetement before adding items
    while (myReader.Read())
    {
    	string sName = myReader.GetString("film");
    	comboBox1.Items.Add(sName);
    	comboBox2.Items.Add(sName);
    }
