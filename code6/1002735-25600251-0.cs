    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ShowForms();//Show the forms
        }
        private async void ShowForms()
        {
            ShowOnMonitor(1);
            await Task.Delay(15000);//15 seconds, adjust it for your needs.
            ShowOnMonitor(2);
        }
        private void ShowOnMonitor(int showOnMonitor)
        {
            Screen[] allScreens = Screen.AllScreens;
            Rectangle screenBounds = allScreens[showOnMonitor - 1].Bounds;
            Form1 f = new Form1
            {
                FormBorderStyle = FormBorderStyle.None,
                Left = screenBounds.Left,
                Top = screenBounds.Top,
                Height = screenBounds.Height,
                Width = screenBounds.Width,
                StartPosition = FormStartPosition.Manual
            };
            f.Show();//Use show, not ShowDialog.
        }
    }
