    public partial class Form1 : Form
    {
        private List<Panel> _panels;
        private int _currentPanelIndex; 
        private List<Color> _colors;      
        public Form1()
        {
            InitializeComponent();
            _panels = new List<Panel> { panel_Red, panel_Yellow, panel_Green };
            _colors = new List<Color> {Color.Red,Color.Yellow,Color.Green};
            _currentPanelIndex = 0;
            
            timer1.Start();
        }
        private void UpdatePanels()
        {
            for (int index = 0; index < 3; index++)
            {
                if (index.Equals(_currentPanelIndex))
                {
                    //current panel to be green
                    _panels[index].BackColor = _colors[index];
                }
                else
                {
                    //others are gray
                    _panels[index].BackColor = Color.Gray;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //set current colors
            UpdatePanels();
            //move to next panel
            _currentPanelIndex++;
            //reset to start from first panel
            if (_currentPanelIndex.Equals(3))
            {
                _currentPanelIndex = 0;
            }
        }
    }
