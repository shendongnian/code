    public partial class Form1 : Form
    {
        private readonly MyNewClass _myNewClass;
        public Form1()
        {
            InitializeComponent();
            _myNewClass = new MyNewClass();
            _myNewClass.PanelAdded += PanelAdded;
        }
        private void PanelAdded(object sender, DisplayPanelsEventArgs e)
        {
            var panels = e.AllPanels; // Add the panels somewhere on the UI ;)
        }
    }
    internal class MyNewClass
    {
        private IList<Panel> _panels = new List<Panel>();
        public void AddPanel(Panel panel)
        {
            _panels.Add(panel);
            OnPanelAdded(new DisplayPanelsEventArgs(_panels, panel)); // raise event, everytime a panel is added
        }
        
        protected virtual void OnPanelAdded(DisplayPanelsEventArgs e)
        {
            EventHandler<DisplayPanelsEventArgs> handler = PanelAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event EventHandler<DisplayPanelsEventArgs> PanelAdded;
    }
    internal class DisplayPanelsEventArgs : EventArgs
    {
        public DisplayPanelsEventArgs(IList<Panel> allPanels, Panel panelAddedLast)
        {
            AllPanels = allPanels;
            PanelAddedLast = panelAddedLast;
        }
        public IList<Panel> AllPanels { get; private set; }
        public Panel PanelAddedLast { get; private set; }
    }
