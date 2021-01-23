    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            BindingList<BindingClass> list = new BindingList<BindingClass>();
            list.Add(new BindingClass { ID = 1, Name = "bc1" });
            list.Add(new BindingClass { ID = 2, Name = "bc2" });
            list.Add(new BindingClass { ID = 3, Name = "bc3" });
            comboBox1.DataSource = list;
            // If you want bind to class use this code. Selected property will contain BindingClass instance, selected in combobox
            //comboBox1.DisplayMember = "Name";
            //comboBox1.DataBindings.Add("SelectedValue", this, "Selected", true, DataSourceUpdateMode.OnPropertyChanged);
            // Use label to view Selected value
            //label1.DataBindings.Add("Text", this, "Selected", true, DataSourceUpdateMode.OnPropertyChanged);
            // OR
            // If you want bind to ID use this code. SelectedId property of the form will contain ID value, selected in combobox
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.DataBindings.Add("SelectedValue", this, "SelectedId", true, DataSourceUpdateMode.OnPropertyChanged);
            // Use label to view SelectedId value
            label1.DataBindings.Add("Text", this, "SelectedId", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public BindingClass Selected { get; set; }
        public int SelectedId { get; set; }
    }
