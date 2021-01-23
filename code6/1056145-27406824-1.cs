    public Form1()
    {
      InitializeComponent();
      this.First = new BindingList<Example>()
      {
        new Example() { Foo = "foo1", Bar = "bar1" },
        new Example() { Foo = "foo2", Bar = "bar2" }
      };
      this.Second = new BindingList<Example>();
      this.dataGridView1.DataSource = this.First;
      this.dataGridView2.DataSource = this.Second;
      DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
      btnCol.HeaderText = "Transfer";
      btnCol.Name = "Transfer";
      btnCol.Text = "Transfer";
      btnCol.UseColumnTextForButtonValue = true;
      this.dataGridView1.Columns.Add(btnCol);
      this.dataGridView1.CellClick += new DataGridViewCellEventHandler(col_Click);
    }
    public BindingList<Example> First { get; set; }
    public BindingList<Example> Second { get; set; }
    public void col_Click(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex == 0) // The button column somehow is column 0, Foo is 1, and Bar is 2.
      {
        this.Second.Clear();
        this.Second.Add(this.First[e.RowIndex]);
      }
    }
