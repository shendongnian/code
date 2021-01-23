    if (root is ExtendedPanel) {
      if (panel.HasBorders && panel.AutoScroll) {
        // special case: we have to wrap this panel inside of another panel for the border to not mess up when scrolling
        ExtendedPanel container = new ExtendedPanel();
        container.Name = "container"; // for debugging, so we can see if a control is a container or not
        container.Left = panel.Left;
        container.Top = panel.Top;
        container.Width = panel.Width;
        container.Height = panel.Height;
        container.BackColor = panel.BackColor;
        container.ForeColor = panel.ForeColor;
        container.BorderStyle = panel.BorderStyle;
        container.HasBorders = panel.HasBorders;
        container.BorderColor = panel.BorderColor;
        container.Anchor = panel.Anchor;
        Control parent = panel.Parent;
        container.Controls.Add(panel);
        parent.Controls.Add(container);
        panel.HasBorders = false;
        panel.Location = new Point(1, 1);
        panel.Size = new Size(container.Width - 2, container.Height - 2);
      }
    }
