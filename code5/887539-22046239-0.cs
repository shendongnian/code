    class UIcode
    {
        private Welcome_Form Welcome;
        private AnotherForm_Form AnotherForm;
        public UIcode() // Renamed Constructor
        {
            Welcome = new Welcome_Form();
            Application.Run(Welcome);
        }
        public void openAnotherForm()
        {
            Welcome.Hide();
            AnotherForm = new AnotherForm_Form();
            AnotherForm.ShowDialog();
        }
    }
    public partial class Welcome_Form : Form
    {
        public Welcome_Form()
        {
            InitializeComponent();
        }
        private void TheButton_Click(object sender, EventArgs e)
        {
            // Create an instance UICode
            UICode instance = new UICode();
            // Call the method from the instance, not from the class.
            instance.openAnotherForm();
        }
    }
