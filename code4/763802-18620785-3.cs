    partial class MainForm:Form
    {
        OptionsForm optForm;
        ............
        ............
        public MainForm()    //Constructor
        {
            initialiseComponent();
            optForm = new OptionsForm();
            ........
        }
        .......
        private button1_Click(object sender, EventArgs e)
        {
            optForm.Show();    // or ShowDialog()
        }
    }
