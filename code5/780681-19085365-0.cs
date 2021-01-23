    public partial class Form1 : Form
    {
        List<customComboBoxItem> customItem = new List<customComboBoxItem>();
        public Form1()
        {
            InitializeComponent();
            customItem.Add(new customComboBoxItem("text1", "id1"));
            customItem.Add(new customComboBoxItem("text2", "id2"));
            customItem.Add(new customComboBoxItem("text3", "id3"));
            customItem.Add(new customComboBoxItem("text4", "id4"));
            comboBox1.DataSource = customItem;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show( ((customComboBoxItem)comboBox1.SelectedItem).Text + " " 
                             + ((customComboBoxItem)comboBox1.SelectedItem).Value); 
        }
    }
    public class customComboBoxItem
    {
        private string text;
        private string value;
     
        public customComboBoxItem(string strText, string strValue)
        {
            this.text = strText;
            this.value = strValue;
        }
        public string Text
        {
            get { return text; }
        }
        public string Value
        {
            get { return value; }
        }
    }
