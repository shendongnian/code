    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        var data = new DataTable();
        lnkSynEvent.Click += new EventHandler((s, a) => lnkSynEvent_Click(s, a, data));
      }
    }
