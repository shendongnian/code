    public override void Init()
    {
      this.BeginRequest += MvcAppliction_BeginRequest;
    }
    private void MvcApplication_BeginRequest(object sender, EventArgs e)
    {
      ...
    }
