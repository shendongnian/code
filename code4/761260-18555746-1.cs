       public Form1()
        {
            InitializeComponent();
        }
       private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Subscribe(form2);
            form2.ShowDialog();
        }
        private void Subscribe(Form2 form2)
        {
            form2.dataSender += new Form2.DataSender(GetDataFromForm2);
        }
        private void GetDataFromForm2(object dataObject)
        {
            // Do somthing with data 
        }
