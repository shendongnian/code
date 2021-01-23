     public Paragraph MyParagraph
      {
        get { return (Paragraph)this.GetValue(MyParagraphProperty); }
        set { this.SetValue(MyParagraphProperty, value); } 
      }
      public static readonly DependencyProperty MyParagraphProperty = DependencyProperty.Register(
        "MyParagraph", typeof(Paragraph), typeof(UserControl1),new PropertyMetadata(null));
