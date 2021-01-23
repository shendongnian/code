    public partial class RoadSign1Meaning : Form
    {
        public RoadSign1Meaning()
        {
            InitializeComponent();
        }
    
        private void StopButton_Click(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now - TempStore.StartTime;             
            // ...
        }
    }
