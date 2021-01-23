    public int chartRowNumber = 0;
        public Form2()
        {
            InitializeComponent();
            Form1 f = new Form1();
            DataTable PatientTable = f.ds.Tables[0];
            listBox1.Items.Add(PatientTable.Rows[chartRowNumber].ItemArray[0].ToString());
        }
    public Form2(int rowIndex)
        {
            InitializeComponent();
            Form1 f = new Form1();
            DataTable PatientTable = f.ds.Tables[rowIndex];
            listBox1.Items.Add(PatientTable.Rows[chartRowNumber].ItemArray[0].ToString());
        }
