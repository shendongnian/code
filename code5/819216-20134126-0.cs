      GraphicsPath grp = new GraphicsPath();
      // Create an open figure
      grp.AddLine(10, 10, 10, 50); // a of polygon
      grp.AddLine(10, 50, 50, 50); // b of polygon
      grp.CloseFigure();           // close polygon
      // Create a Region regarding to grp
      Region reg = new Region(grp);
