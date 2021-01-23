        List<string> DepartmentsPermanent;
        List<string> DepartmentsTemporary;
        public Form1()
        {
            InitializeComponent();
    
            DepartmentsPermanent = new List<string>();
            DepartmentsPermanent.Add("EEE");
            DepartmentsPermanent.Add("CSE");
            DepartmentsPermanent.Add("E&I");
            DepartmentsPermanent.Add("Mechanical");
            comboBox1.DataSource = DepartmentsPermanent;
            //here you assign the values to other List
            DepartmentsTemporary = DepartmentsPermanent.ToList();
            
          
        }
        //Now if you have selected EEE from the list and you want to remove on selection
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && DepartmentsTemporary != null)
            {
                DepartmentsTemporary.Remove(comboBox1.SelectedItem.ToString());
                comboBox1.DataSource = DepartmentsTemporary;
                
            }
            //If you want to assign the default values again you can just assign the PermanentList
            //comboBox1.DataSource = DepartmentsPermanent;
        }
