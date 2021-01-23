    public Form1()
    {
      InitializeComponent();
      this.Products = YourQueryCall();
      this.FillDGView();
    }
    public BindingList<Product> Products { get; set; }
    public void FillDGView()
    {
      DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
      col1.Name = "Product ID";
      col1.ValueType = typeof(int);
      dataGridView1.Columns.Add(col1);
      DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
      col2.Name = "Product Name";
      col2.ValueType = typeof(string);
      dataGridView1.Columns.Add(col2);
      DataGridViewComboBoxColumn col3 = new DataGridViewComboBoxColumn();
      col3.Name = "Version";
      col3.ValueType = typeof(double);
      dataGridView1.Columns.Add(col3);
      for (int i = 0; i < this.Products.Count; i++)
      {
        DataGridViewRow row = (DataGridViewRow)(dataGridView1.Rows[0].Clone());
        DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)(row.Cells[0]);
        textCell.ValueType = typeof(int);
        textCell.Value = this.Products[i].ID;
        textCell = (DataGridViewTextBoxCell)(row.Cells[1]);
        textCell.ValueType = typeof(string);
        textCell.Value = this.Products[i].Name;
        DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)(row.Cells[2]);
        comboCell.ValueType = typeof(double);
        comboCell.DataSource = this.Products[i].Version;
        comboCell.Value = this.Products[i].Version[0];
        dataGridView1.Rows.Add(row);
      }
    }
