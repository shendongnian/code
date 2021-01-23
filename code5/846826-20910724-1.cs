    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            DateTime minDate = Convert.ToDateTime(mindate.Value);
            DateTime maxDate = Convert.ToDateTime(maxdate.Value);
            foreach ( DataGridViewComboBoxColumn cmbCol in dataGridView1.Columns) {
                cmbCol.Items.Clear();
                while (minDate.Day < maxDate.Day) {
                    cmbCol.Items.Add($"{minDate.Day}/{minDate.Month}/{minDate.Year}");
                   minDate= minDate.AddDays(1);
                }
            }
        }
    }
