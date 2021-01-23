    private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == tabPage2.Name)
            {
                table = Items.Get();
                if (table.Rows.Count > 0)
                {
                    //Update comboBox1 using table
                    comboBox1.DataSource = table;
                    comboBox1.DisplayMember = "Item_ID";
                    //Using 1st row and 1st coloumn in function argument to get colors
                    //Color.Get(string itemID) returns dataTable, which I used for comboBox2 DataSource
                    comboBox2.DataSource = Color.Get(table.Rows[0].ItemArray[0].ToString());
                    comboBox2.ValueMember = "Color_ID";
                    comboBox2.DisplayMember = "Color_Name";
                }
            }
        }
