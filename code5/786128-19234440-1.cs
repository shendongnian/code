    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack) {
            PanelTextBox.Focus();
            myTimer.Interval = 3000;
            myTimer.Enabled = true;
        }
    }
    
    protected void myTimer_Tick(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(2000);
        TimeLiteral.Text = DateTime.UtcNow.Ticks.ToString();
    }
