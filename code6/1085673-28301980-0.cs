    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }
        public override void Install(IDictionary savedState)
        {
            savedState.Add("InstallDir", Context.Parameters["dir"]);
            base.Install(savedState);
        }
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            Start(savedState);
        }
        private void Start(IDictionary savedState)
        {
            try
            {
                string DirPath = (string)savedState["InstallDir"];
                if (!string.IsNullOrEmpty(DirPath))
                {
                    Process.Start(DirPath + @"\WindowsFormsApplication1.exe");
                }
            }
            catch
            {
            }
        }
    }
