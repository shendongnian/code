    public partial class MainForm : Form
    {
        private DataSet _dataSet = new DataSet();
        public MainForm()
        {
            InitializeComponent();
            comboBox1.DataSource = _dataSet.Tables[0];
            comboBox1.DisplayMember = "autorius";
            comboBox1.ValueMember = "aut_id";
        }
        public void comboboxes()
        {
            using (OracleConnection conn = new OracleConnection("Data Source=localhost;Persist Security Info=True;User ID=kursinis1;Password=1234;Unicode=True"))
            {
                conn.Open();
                using (OracleDataAdapter data1 = new OracleDataAdapter("select aut_id, (aut_vardas || ' ' || aut_pavarde) AS autorius from autoriai", conn))
                {
                    data1.SelectCommand.CommandType = CommandType.Text;
                    data1.Fill(_dataSet);
                }
            }
        }
    }
