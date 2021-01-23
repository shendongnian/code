    public Form1()
    {
        InitializeComponent();
        List<ToolMessages> test = new List<ToolMessages>();
        ToolMessages tool = new ToolMessages();
        tool.IsPass = true;
        tool.ToolMessageReply = string.Empty;
        tool.ToolMessageRequest = "x";
        test.Add(tool);
    
        dataGridView1.AutoGenerateColumns = false;
    
        DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
        col1.DataPropertyName = "ToolMessageRequest";
        col1.HeaderText = "Request";
        dataGridView1.Columns.Add(col1);
    
        BindingList<ToolMessages> bind = new BindingList<ToolMessages>(test);
    
        dataGridView1.DataSource = bind;
        dataGridView1.Show();
    }
