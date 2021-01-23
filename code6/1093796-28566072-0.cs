    public RichTextBoxScrollBars ScrollBars {
      get {
        return this.sb;
      }
      set {
        this.sb = value;
        this.RecreateHandle();
      }
    }
    protected override void OnHandleCreated(EventArgs e) {
      base.OnHandleCreated(e);
      UpdateScrollBars();
    }
