    public myControl() {
      this.DoubleBuffered = true;
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.Selectable, true);
      this.TextComponent.PropertyChanged += TextComponent_PropertyChanged;
    }
    void TextComponent_PropertyChanged(object sender, PropertyChangedEventArgs e) {
      this.Invalidate();
    }
