    private void lbMethods_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (lbMethods.SelectedIndex)
        {
            case (int)Methods.none:
                break;
            case (int)Methods.Susan:
                Log("Starting Susan Edge Detection");
                Progressing("Please wait for edge detection");
    
                var dialog = new FrmProcessing();
                dialog.StartTaskFunc = () =>
                    Task.Run(ProcessSusan);
                dialog.ShowDialog();
    
                Log("Detection Finished");
                Progressing("", false);
                break;
            default:
                break;
        }
    }
    
    public partial class FrmProcessing : Form
    {
        public Func<Task> StartTaskFunc { get; set; }
    
        public string description { get; set; }
    
        public FrmProcessing(string description)
        {
            InitializeComponent();
            lblDescription.Text = description;
    
            // async event handler for "Form.Load"
            this.Load += async (s, e) =>
            {
                // start the task and await it
                await StartTaskFunc();
                // close the modal form when the task finished
                this.Close();
            };
        }
    }
