    protected void Page_Load(object sender, EventArgs e)
    {
      var miniprofiler = MiniProfiler.Current;
             
      var htmlString = miniprofiler.Render();
    
      Literal1.Text = htmlString.ToString();
    }
