    protected override void OnSizeChanged(EventArgs e){
      base.OnSizeChanged(e);
      Invalidate();
    }
    protected override void OnTextChanged(EventArgs e){
      base.OnTextChanged(e);
      Invalidate();
    }
    protected override void OnFontChanged(EventArgs e){
      base.OnFontChanged(e);
      Invalidate();
    }
    protected override void OnForeColorChanged(EventArgs e){
      base.OnForeColorChanged(e);
      Invalidate();
    }
