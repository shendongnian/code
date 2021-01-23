    private List<KeyHandler> Handlers = new List<KeyHandler>();
	public MainForm()
	{
		InitializeComponent();
		Handlers.Add(new KeyHandler(Keys.Z, this));
		Handlers.Last().Register();
		Handlers.Add(new KeyHandler(Keys.H, this));
		Handlers.Last().Register();
	}
	protected override void WndProc(ref Message m)
	{
		if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
		{
			int key = m.WParam.ToInt32();
			HandleHotkey(Handlers.First(entry => entry.GetHashCode() == key).Key);
		}
		base.WndProc(ref m);
	}
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Handlers.ForEach(entry => entry.Unregiser());
    }
