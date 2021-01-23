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
        #region DataBind
        private void LoadData()
        {
            // Since Fill Methods are void and without parameters,
            // you can use the Invoke method without the need to specify delegates.
            Invoke((MethodInvoker)FillPersonale);
            Invoke((MethodInvoker)FillNatanti);
            Invoke((MethodInvoker)FillScuole);
        }
        public void FillPersonale()
        {
            this.PersonaleTableAdapter.Fill(this.DEVRAC_NauticheDataSet.PERSONALE);
        }
        public void FillNatanti()
        {
            this.NatantiTableAdapter.Fill(this.DEVRAC_NauticheDataSet.NATANTI);
        }
        public void FillScuole()
        {
            this.ScuoleTableAdapter.Fill(this.DEVRAC_NauticheDataSet.SCUOLE);
        }
        #endregion
    }
