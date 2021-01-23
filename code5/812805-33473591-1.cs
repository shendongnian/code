    static SqlConnection myConnection;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            myConnection = new SqlConnection("server=localhost;" +
                                                          "Trusted_Connection=true;" +
                 "database=zxc; " +
                                                          "connection timeout=30");
            try
            {
                myConnection.Open();
                label1.Text = "connect successful";
            }
            catch (SqlException ex)
            {
                label1.Text = "connect fail";
                MessageBox.Show(ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            String st = "INSERT INTO supplier(supplier_id, supplier_name)VALUES(" + textBox1.Text + ", " + textBox2.Text + ")";
            SqlCommand sqlcom = new SqlCommand(st, myConnection);
            try
            {
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("insert successful");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
