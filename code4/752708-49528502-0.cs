    private void button1_Click(object sender, EventArgs e)
        {
            ComboBox c1 = new ComboBox();
            Point loc1 = new Point(50, 80);
             Point loc2 = new Point(250, 80);
            c1.Name = "combobox1";              
            c1.Items.Add("ABC");
            c1.Items.Add("XYZ");
            c1.Items.Add("PQR");
            c1.SelectedIndexChanged += new EventHandler(changevaluesincombobox2);
            c1.Location = loc1;
            ComboBox c2 = new ComboBox();
            c2.Name = "combobox2";
            c2.Location = loc2;
            this.Controls.Add(c1);
            this.Controls.Add(c2);
        }
        private void changevaluesincombobox2(object sender, EventArgs e)
        {
            ComboBox dummy = sender as ComboBox;
            if(dummy.SelectedItem == "ABC")
            ((ComboBox)dummy.Parent.Controls["combobox2"]).Items.Add("Your Intended items");
           
            
        }
        
    
