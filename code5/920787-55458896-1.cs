    public partial class Form1 : Form
    {
        private async Task Initialize()
        {
            // replace code here...
            await Task.Delay(1000);
        }
        private async Task Run(string myString)
        {
            // replace code here...
            await Task.Delay(1000);
        }
        public Form1()
        {
            InitializeComponent();
            // you don't have to await nothing.. (the thread must be running)
            ASyncHelper.RunAsync(Initialize);
            ASyncHelper.RunAsync(Run, "test");
        }
    }
