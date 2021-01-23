    public partial class Form1 : Form
    {
        BindingList<PropertyInfo> DataSource = new BindingList<PropertyInfo>();
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = new BindingList<PropertyInfo>(typeof(Person).GetProperties());
            // if want to specify only name (not type-name/property-name tuple)
            comboBox.DisplayMember = "Name";
        }
    }
