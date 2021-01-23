    var width = this.Width - panel1.Width - panel1.Margin.Horizontal
			        - panel2.Width - panel2.Margin.Horizontal;
    pb.Size = new Size(width, 300); // put your needed height here
    pb.Top = this.Height/2 - panel3.Height/ 2;
    pb.Left = panel2.Left + panel2.Width + panel2.Margin.Right;
