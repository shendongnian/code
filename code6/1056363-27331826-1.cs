    private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
      if (panel1.Bounds.Contains( this.PointToClient( Cursor.Position )  ))
      {
        if (e.KeyValue == 33) panel1.AutoScrollPosition = 
          new Point(panel1.AutoScrollPosition.X, Math.Abs(panel1.AutoScrollPosition.Y) - 10);
        if (e.KeyValue == 34) panel1.AutoScrollPosition = 
          new Point(panel1.AutoScrollPosition.X, Math.Abs(panel1.AutoScrollPosition.Y) + 10);
      }
    }
