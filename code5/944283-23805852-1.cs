    public partial class MainForm : Form
        {
            private readonly DataModule _dataModule = DataModule.GetInstance();
    
            private delegate void RefreshMessageQueueTable();
    
            public MainForm()
            {
                InitializeComponent();
                _dataModule.MessageQueueTableUpdate += () =>
                {
                    if (dataGridView1.InvokeRequired)
                    {
                        dataGridView1.Invoke(new RefreshMessageQueueTable(_dataModule.LoadMessageQueueDataTable));
                    }
                    else
                    {
                        _dataModule.LoadMessageQueueDataTable();
                    }
                };
            }
    
            private void MainForm_Load(object sender, EventArgs e)
            {
                dataGridView1.DataSource = _dataModule.AppDataSet;
                dataGridView1.DataMember = "MESSAGEQUEUE";
                _dataModule.LoadMessageQueueDataTable();
            }
        }
