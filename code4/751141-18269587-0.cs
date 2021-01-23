     public Take_INput_form(List<string > input)
        {
            InitializeComponent();
            Final_input_display(input);
        }
        public void Final_input_display(List<string> temp)
        {
            for (int i = 0; i <temp.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = temp [i];
            }
        }
