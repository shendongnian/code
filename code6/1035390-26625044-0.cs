        DataTable tab1 = new DataTable(); 
        tab1.Columns.Add("Name",typeof(string));
        tab1.Columns.Add("Value", typeof(string));
        tab1.Columns.Add("ID", typeof(int));
        tab1.Rows.Add("name1", "value1", 1);
        tab1.Rows.Add("name2", "value2", 2);
        tab1.Rows.Add("name3", "value3", 3);
        comboBox1.DataSource = tab1;
        comboBox1.ValueMember = "Value";
        comboBox1.DisplayMember = "Name";
        
        DataTable tab2 = new DataTable();
        tab2.Columns.Add("Name", typeof(string));
        tab2.Columns.Add("Value", typeof(string));
        tab2.Columns.Add("Tab1_ID", typeof(int));
        tab2.Rows.Add("1_name1", "_value1", 1);
        tab2.Rows.Add("1_name2", "_value2", 1);
        tab2.Rows.Add("1_name3", "_value3", 1);
        tab2.Rows.Add("2_name1", "_value1", 2);
        tab2.Rows.Add("2_name2", "_value2", 2);
        tab2.Rows.Add("2_name3", "_value3", 2);
        tab2.Rows.Add("3_name1", "_value1", 3);
        tab2.Rows.Add("3_name2", "_value2", 3);
  
        // here use DataView instaed of directly using the table:
        comboBox2.DataSource = tab2.DefaultView;
        comboBox2.ValueMember = "Value";
        comboBox2.DisplayMember = "Name";
        comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        comboBox1.SelectedIndex = 0;
