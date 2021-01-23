    void panel1_MouseMove(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        panel1.DoDragDrop("test", DragDropEffects.Move);
      }
    }
    void panel1_DragEnter(object sender, DragEventArgs e) {
      e.Effect = DragDropEffects.Move;
    }
    void panel1_DragOver(object sender, DragEventArgs e) {
      Point p = panel1.PointToClient(new Point(e.X, e.Y));
      if (p.Y < 16) {
        scrollJump = -20;
        if (!scrollTimer.Enabled) {
          scrollTimer.Start();
        }
      } else if (p.Y > panel1.ClientSize.Height - 16) {
        scrollJump = 20;
        if (!scrollTimer.Enabled) {
          scrollTimer.Start();
        }
      } else {
        if (scrollTimer.Enabled) {
          scrollTimer.Stop();
        }
      }
    }
    void panel1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e) {
      if (e.Action != DragAction.Continue) {
        scrollTimer.Stop();
      }
    }
