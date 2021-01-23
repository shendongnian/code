    public Form1()
    {
      InitializeComponent();
      OnRefreshGrid(null, null);
      Timer ticker = new Timer();
      ticker.Interval = 250;
      ticker.Tick += OnRefreshGrid;
      ticker.Start();
    }
    void OnRefreshGrid(object sender, EventArgs e)
    {
      BindingSource source = new BindingSource();
      var table = new DataTable("Process List");
      Process[] processes = Process.GetProcesses();
      table.Columns.Add("Name");
      table.Columns.Add("Id");
      for (int i = 0; i < processes.Length; ++i)
      {
        table.Rows.Add(new object[] { processes[i].ProcessName + ".exe", processes[i].Id });
      } 
      table.AcceptChanges();
      source.DataSource = table;
      int scroll = dataGridView1.FirstDisplayedScrollingRowIndex;
      dataGridView1.DataSource = source;
      if (scroll != -1)
        dataGridView1.FirstDisplayedScrollingRowIndex = scroll;
    }
