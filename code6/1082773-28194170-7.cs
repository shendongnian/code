    public Form1 ParentForm
        {
            get;
            set;
        } 
        public Form2(Form1 parent)
        {
            InitializeComponent();
            ParentForm = parent;
            selectRows();
        }
        public void selectRows()
        { 
            foreach (DataGridViewColumn column in ParentForm.dataGridView1.Columns)
            {
                //Your code
            } 
            foreach (DataGridViewRow row in ParentForm.dataGridView1.SelectedRows)
            {
                 //Your code
            } 
        }
