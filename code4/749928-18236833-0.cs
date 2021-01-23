    protected void Page_Load(object sender, EventArgs e)
    {
      var data = new DataTable();
      lnkSynEvent.Click += new EventHandler((s, a) => lnkSynEvent_Click(s, a, data));
    }
    
    protected void lnkSynEvent_Click(object sender, EventArgs e, DataTable data)
    {
    
    }
