        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //This is simulating an add...First Language will be displayed on form2, 
            //which is English
            Form2 form = new Form2();
            form.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //This is simulating an edit...this will display french 
            //(or whatever is passed in)
            Form2 form = new Form2();
            form.Initialize(Languages.French);
            form.ShowDialog();
        }
_________________________________________________________________________________
        Languages editValue;
        bool isEdit = false;
        public Form2()
        {
            InitializeComponent();
        }
        public void Initialize(Languages var)
        {
            editValue = var;
            isEdit = true;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(Languages));
            if (isEdit)
            {
                comboBox1.SelectedItem = editValue;
            }
        }
