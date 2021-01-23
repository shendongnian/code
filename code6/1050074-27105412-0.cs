    public partial class Form1 : Form
    {
        private BindingList<Class> DataSource = new BindingList<Class>();
    
        public Form1()
        {
            InitializeComponent();            
            dgvLoadTable.DataSource = DataSource;            
        }
        
        private void dgvLoadTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue.GetType() != dgvLoadTable.CurrentCell.ValueType.UnderlyingSystemType)
                MessageBox.Show("Input type is wrong");
        }
    }
    
    public class Class
    {
        public string StringData { get; set; }
        public int IntData { get; set; }
    }
