    public Form1()
    {
        InitializeComponent();
        var reports = new List<Tuple<string, Type>>();
    
        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            if (type.IsSubclassOf(typeof(XtraReport)))
                reports.Add(new Tuple<string, Type>(type.Name, type));
    
        lookUpEdit1.Properties.DataSource = reports;
        lookUpEdit1.Properties.DisplayMember = "Item1";
        lookUpEdit1.Properties.ValueMember = "Item2";
        lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("Item1","Report"));
    }
    private void simpleButton1_Click(object sender, EventArgs e)
    {
        var value = lookUpEdit1.EditValue;
        if (value == null)
            return;
        var report = (XtraReport)Activator.CreateInstance((Type)value);
        var tool = new ReportPrintTool(report);
        tool.ShowPreview();
    }
