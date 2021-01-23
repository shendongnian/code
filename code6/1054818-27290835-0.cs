    public partial class ScuoleNauticheForm : Form
    {
        private readonly TaskManager _taskManager;
        public ScuoleNauticheForm()
        {
            InitializeComponent();
            _taskManager = TaskManager.GetInstance();
        }
        private void ScuoleNauticheForm_Load(object sender, EventArgs e)
        {
            _taskManager.StartNewTask(LoadData);
        }
        #region Delegates
        public delegate void FillPersonaleCallBack();
        public delegate void FillNatantiCallBack();
        public delegate void FillScuoleCallBack();
        #endregion
        #region DataBind
        private void LoadData()
        {
            FillPersonale();
            FillNatanti();
            FillScuole();
        }
        public void FillPersonale()
        {
            if (PersonaleDataGridView.InvokeRequired)
            {
                FillPersonaleCallBack d = new FillPersonaleCallBack(FillPersonale);
                Invoke(d);
            }
            else
            {
                this.PersonaleTableAdapter.Fill(this.DEVRAC_NauticheDataSet.PERSONALE);
            }
        }
        public void FillNatanti()
        {
            if (NatantiDataGridView.InvokeRequired)
            {
                FillNatantiCallBack d = new FillNatantiCallBack(FillNatanti);
                Invoke(d);
            }
            else
            {
                this.NatantiTableAdapter.Fill(this.DEVRAC_NauticheDataSet.NATANTI);
            }
        }
        public void FillScuole()
        {
            if (ScuoleDataGridView.InvokeRequired)
            {
                FillScuoleCallBack d = new FillScuoleCallBack(FillScuole);
                Invoke(d);
            }
            else
            {
                this.ScuoleTableAdapter.Fill(this.DEVRAC_NauticheDataSet.SCUOLE);
            }
        }
        #endregion
    }
