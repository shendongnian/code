    public partial class MainForm : Form, IRestrictedInterfaceOfMainForm
    {
        public void AddStuff(string stuff)
        {
            comboCurves.Items.Add(stuff);
        }
    }
    
    public interface IRestrictedInterfaceOfMainForm
    {
        void AddStuff();
    }
    public partial class SubForm : Form
    {
        private IRestrictedInterfaceOfMainFormmainForm mainForm;
        public SubForm(IRestrictedInterfaceOfMainFormmainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
    }
