    public partial class Form2 : Form
    {
        public Form2(int chartRowNumber, DataTable form1Table)
        {
            InitializeComponent();
            listBox1.Items.Add(form1Table.Rows[chartRowNumber].ItemArray[0].ToString());
        }
    }
