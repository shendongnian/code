    public partial class KeyboardSettingsForm : Form
    {
        private mainForm _mForm;
        public KeyboardSettingsForm(mainForm mForm)
        {
            InitializeComponent();
            this._mForm = mForm;//Did you mean this?
            this.MdiParent = _mForm;
            this.Shown += new System.EventHandler(this.KeyboardSettingsForm_Shown);
        }
    }
