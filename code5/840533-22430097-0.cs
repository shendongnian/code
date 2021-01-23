    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            HookSpecificButton(this.MyButton, this.OnButtonClicked);
        }
        private void OnButtonClicked(object sender, EventArgs e)
        {
        }
        public static void HookSpecificButton(Button specificButton, EventHandler eh)
        {
            specificButton.Click += (o, e) => eh(o, EventArgs.Empty);
        }
    }
