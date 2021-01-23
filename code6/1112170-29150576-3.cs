    public class Example
    {
      public string Foo { get; set; }
      public string Bar { get; set; }
    }
    public Form1()
    {
      InitializeComponent();
      this.AddDataSource();
    }
    public BindingList<Example> Examples { get; set; }
    private void AddDataSource()
    {
      this.Examples = new BindingList<Example>()
      {
        new Example() { Bar = "Bar 1", Foo = "Foo 1"},
        new Example() { Bar = "Bar 2", Foo = "Foo 2"},
        new Example() { Bar = "Bar 3", Foo = "Foo 3"},
        new Example() { Bar = "Bar 4", Foo = "Foo 4"},
      };
      this.dataGridView1.DataSource = this.Examples;
    }
    private void AddCheckColumn()
    {
      DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
      col.Name = "Checked";
      if (!this.dataGridView1.Columns.Contains(col))
      {
        this.dataGridView1.Columns.Add(col);
        string values = "true;false;true;false;";
        List<string> vals = values.TrimEnd(';').Split(';').ToList();
        int maxRows = Math.Min(this.dataGridView1.Rows.Count, vals.Count);
        for (int i = 0; i < maxRows; i++)
        {
          DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)this.dataGridView1.Rows[i].Cells["Checked"];
          cell.Value = vals[i] == "true";
        }
      }
    }
