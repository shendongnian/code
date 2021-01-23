    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void StartButton_Click(object sender, EventArgs e)
        {
            TempStore.StartTime = DateTime.Now;
    
            // ...
        }
    }
    public partial class RoadSign1Meaning : Form
    {
        public RoadSign1Meaning()
        {
            InitializeComponent();
        }
    
        private void StopButton_Click(object sender, EventArgs e)
        {
            TempStore.EndTime = DateTime.Now;
            
            // ...
        }
    }
