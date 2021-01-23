        List<string> lst;
        public Form2()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/mm/yyyy  HH:mm";          
            lst = new List<string>();
        }
        private void button2_Click(object sender, EventArgs e)
        {            
            lst.Remove(listBox1.SelectedItem.ToString());
            BindList();            
        }
        private void button1_Click(object sender, EventArgs e)
        {        
            string s = textBox1.Text + ", " + Convert.ToDateTime(this.dateTimePicker1.Value).ToString("dd/mm/yyyy HH:mm");
            lst.Add(s);
            BindList();          
        }
        private void BindList()
        {  
            lst = (lst.OrderByDescending(s => s.Substring(s.LastIndexOf(" "), s.Length - s.LastIndexOf(" ")))).ToList();
            listBox1.DataSource = lst;
        }
   
