    public partial class Form2 : Form
    {
        class Item
        {
            public string Label { get; set; }
            public string Value { get; set; }
        }
        DataGridView _dgv;
        public Form2()
        {
            InitializeComponent();
            _dgv = new DataGridView();
            _dgv.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgv_EditingControlShowing);
            _dgv.DataSource = GetData();
            Controls.Add(_dgv);
        }
        void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (e.Control is TextBox)
            {
                var tb = (TextBox)e.Control;
                tb.ReadOnly = (dgv.CurrentCell.ColumnIndex == 1);
            }
        }
        private BindingList<Item> GetData()
        {
            var result = new BindingList<Item>();
            result.Add(new Item { Label = "Lbl 1", Value = "Val 1" });
            result.Add(new Item { Label = "Lbl 2", Value = "Val 2" });
            result.Add(new Item { Label = "Lbl 3", Value = "Val 3" });
            return result;
        }
    }
