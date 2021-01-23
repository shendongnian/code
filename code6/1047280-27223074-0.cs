            comboBox1.Items.Add(button1);
            comboBox1.Items.Add(button2);
            comboBox1.Items.Add(dateTimePicker1);
            comboBox1.Items.Add(checkBox1);
            comboBox2.Items.Add(button3);
            comboBox2.Items.Add(button4);
            comboBox2.Items.Add(dateTimePicker2);
            comboBox2.Items.Add(checkBox2);
            comboBox3.Items.Add(button5);
            comboBox3.Items.Add(dateTimePicker3);
            comboBox3.Items.Add(checkBox3);
            comboBox3.Items.Add(checkBox4);
            List<ComboBox> ddlList = new List<ComboBox>();
            foreach (Control c in panel1.Controls)
            {
                if (c is ComboBox)
                {
                    ddlList.Add((ComboBox)c);
                }
            }
            List<Control> itemCollection = new List<Control>();
            foreach (ComboBox ddl in ddlList)
            {
                foreach (var li in ddl.Items)
                {
                    itemCollection.Add((Control)li);
                }
            }
