      var Loc = this.PointToScreen(label1.Location);
      Loc = label1.PointToClient(Loc);
      Loc = new Point(Loc.X + 10, Loc.Y + 10);
      label2.Parent = label1;
      label2.Location = Loc;
      label2.BackColor = System.Drawing.Color.Transparent;
