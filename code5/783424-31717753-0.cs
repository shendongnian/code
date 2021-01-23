    public Form1() 
        {
            InitializeComponent();
            var editColumn = new DataGridViewButtonColumn
            {
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "Edit",
                DataPropertyName = "Edit"
            };
            dataGridView1.Columns.Add(editColumn);
        }
