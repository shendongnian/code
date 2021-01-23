        public partial class WizardForm : Form
        {
            public WizardForm()
            {
                 InitializeComponent();
                 // _container is a panel, tabpage, or whatever you want to
                 // keep your "pages" in
                 _container.Controls.AddRange(StepsManager.ViewControls);
            }
        }
