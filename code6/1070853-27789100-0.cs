    public override void DrawTab( Color foreColor,
                                  Color backColor,
                                  Color highlightColor,
                                  Color shadowColor,
                                  Color borderColor,
                                  bool active,
                                  bool mouseOver,
                                  DockStyle dock,
                                  Graphics graphics,
                                  SizeF tabSize )
    {
      if( active )
      {
        Pen p = new Pen( borderColor );
        graphics.DrawRectangle( p, 0, 0, tabSize.Width, tabSize.Height );
        p.Dispose();
      }
      else
      {
        Brush b = Brushes.Peru;
        float dif = tabSize.Height / 4.0f;
        RectangleF r = new RectangleF( 0.0f, dif, 
             tabSize.Width, tabSize.Height - dif - dif );
        graphics.FillRectangle( b, r );
      }
    }
