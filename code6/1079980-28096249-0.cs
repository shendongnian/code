             public Form1()
                {
                    InitializeComponent();
        
                    comboBox1.Items.Add("tablename_1");
                    comboBox1.Items.Add("tablename_2");
                    comboBox1.Items.Add("tablename_3");
                    comboBox1.SelectedIndex = 0;
        
                    comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        
                   
        
                }
                void comboBox1_SelectedIndexChanged(object sender, EventArgs e){
        
                    comboBox2.Items.Clear();
                    switch (comboBox1.SelectedIndex) { 
                        case 0:
                            item_add("column 1 table 1");
                            item_add("column 2 table 1");
                            comboBox2.SelectedIndex = 0;
                            break;
                        case 1:
                            item_add("column 1 table 2");
                            item_add("column 2 table 2");
                            comboBox2.SelectedIndex = 0;
        
                            break;
                        case 2:
                            item_add("column 1 table 3");
                            item_add("column 2 table 3");
                            comboBox2.SelectedIndex = 0;
        
                            break;
                    
                    }
    }
         void item_add(string columname) {
                    comboBox2.Items.Add(columname);
                
                }
