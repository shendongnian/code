    public partial class Form1 : Form
    {
        private bool mouseInPanel;
        private Timer hideTimer;
        public Form1()
        {
            InitializeComponent();
            buttonMenu.MouseEnter += new EventHandler(button_MouseEnter);
            buttonMenu.MouseLeave += new EventHandler(button_MouseLeave);
            mbB1.MouseEnter += panelButton_MouseEnter;
            mbB2.MouseEnter += panelButton_MouseEnter;
            panelMenu.MouseEnter += new EventHandler(panelMenu_MouseEnter);
            panelMenu.MouseLeave += new EventHandler(panelMenu_MouseLeave);
            hideTimer = new Timer {Interval = 100};
            hideTimer.Tick += hidePanel;
        }
        private void button_MouseEnter(object sender, EventArgs e)
        {
            this.panelMenu.Visible = true;
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            hideTimer.Start();
        }
        private void panelMenu_MouseEnter(object sender, EventArgs e)
        {
            mouseInPanel = true;
            this.panelMenu.Visible = true;
        }
        private void panelMenu_MouseLeave(object sender, EventArgs e)
        {
            mouseInPanel = false;
            hideTimer.Start();
        }
        private void panelButton_MouseEnter(object sender, EventArgs e)
        {
            mouseInPanel = true;
            this.panelMenu.Visible = true;
        }
        private void hidePanel(object sender, EventArgs e)
        {
            hideTimer.Stop();
            if (!mouseInPanel) this.panelMenu.Visible = false;
        }
    }
