    public partial class Form1 : Form
    {
        private Dictionary<string, string> _dictionary = new Dictionary<string, string>();
        public Form1(Dictionary<string, string> dictionary)
        {
            InitializeComponent();
            _dictionary = dictionary;
            _UpdateDictionaryView();
        }
        private void _UpdateDictionaryView()
        {
            _UpdateDictionaryListView();
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.AddRange(_dictionary.OrderBy(kvp => kvp.Key).Select(kvp =>
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1, kvp.Key, kvp.Value);
                return row;
            }).ToArray());
        }
        private void _UpdateDictionaryListView()
        {
            listBoxDictionaryView.Items.Clear();
            listBoxDictionaryView.Items.AddRange(
                _dictionary.OrderBy(kvp => kvp.Key)
                            .Select(kvp => string.Format("Key: \"{0}\"; Value: \"{1}\"", kvp.Key, kvp.Value))
                            .ToArray());
        }
        private void buttonAddKeyValuePair_Click(object sender, EventArgs e)
        {
            _dictionary.Add(tboxKey.Text, tboxValue.Text);
            _UpdateDictionaryView();
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            _dictionary[(string)row.Cells[0].Value] = (string)row.Cells[1].Value;
            _UpdateDictionaryView();
            _SaveDictionaryData();
        }
    }
