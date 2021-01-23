        public Form1()
        {
            InitializeComponent();
            // add this line
            DevExpress.UserSkins.OfficeSkins.Register();
            panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl1.LookAndFeel.UseWindowsXPTheme = false;
            panelControl1.LookAndFeel.Style = LookAndFeelStyle.Skin;
            panelControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            var childXtraUserControl = new ChildXtraUserControl {Dock = DockStyle.Fill};
            panelControl1.Controls.Add(childXtraUserControl);
        }
