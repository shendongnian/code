    private Dictionary<string, EventHandler> _buttonEvents;
    public ClassName()
    {
        _buttonEvents = new Dictionary<string, EventHandler>();
        _buttonEvents.Add("btn1", btn1_Click);
        _buttonEvents.Add("btn2", btn2_Click);
    }
    private void btn1_Click(object sender, EventArgs e)
    {
    }
    
    private void btn2_Click(object sender, EventArgs e)
    {
    }
  
    protected override void OnLoad(System.EventArgs e)
	{
        foreach(var c in this.Controls.OfType<System.Windows.Forms.Button>())
        {
            c.Click += _buttonEvents[c.Name];
        };
	}
