    private void Generic_Click(object sender, EventArgs eventArgs)
    {
    }
  
    protected override void OnLoad(System.EventArgs e)
	{
        foreach(var c in this.Controls.OfType<System.Windows.Forms.Button>())
        {
            c.Click += Generic_Click;
        };
	}
