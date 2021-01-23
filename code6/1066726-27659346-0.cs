    public partial class Form1 : Form
    {
        private readonly MyNewClass _myNewClass;
        public Form1()
        {
            InitializeComponent();
            _myNewClass = new MyNewClass();
            _myNewClass.DisplayPanelsInvoked += DisplayPanelsInvoked;
        }
        private void DisplayPanelsInvoked(object sender, DisplayPanelsEventArgs e)
        {
            var panels = e.Panels; // Add the panels somewhere on the UI ;)
        }
    }
    internal class MyNewClass
    {
        private IList<Panel> _panels = new List<Panel>();
        public void AddPanel(Panel panel)
        {
            _panels.Add(panel);
        }
        public void DisplayPanels()
        {
            OnDisplayPanels(new DisplayPanelsEventArgs(_panels));
        }
        protected virtual void OnDisplayPanels(DisplayPanelsEventArgs e)
        {
            EventHandler<DisplayPanelsEventArgs> handler = DisplayPanelsInvoked;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event EventHandler<DisplayPanelsEventArgs> DisplayPanelsInvoked;
    }
    internal class DisplayPanelsEventArgs : EventArgs
    {
        public DisplayPanelsEventArgs(IList<Panel> panels)
        {
            Panels = panels;
        }
        public IList<Panel> Panels { get; private set; }
    }
