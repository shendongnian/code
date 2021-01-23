	Label[] l = new Label[15];
	PictureBox[] pic1 = new PictureBox[15];
	int y_value = 47;
	for (int i = 0; i < 6; ++i)
	{
		l[i] = new Label
		{
			Text = "Test Text",
			Font = new System.Drawing.Font("Calibri", 8, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (128))),
			ForeColor = System.Drawing.Color.White,
			BackColor = System.Drawing.Color.FromArgb(1, 0, 64),
			Size = new System.Drawing.Size(145, 20),
			Location = new Point(30, y_value),
			Anchor = AnchorStyles.Left,
			Visible = true
		};
		pic1[i] = new PictureBox
		{
			Size = new System.Drawing.Size(400, 20),
			Location = new Point(2, y_value - 10),
			Anchor = AnchorStyles.Left,
			Visible = true,
			BackColor = Color.FromArgb(y_value/2, 0, 0)
		};
		y_value += 37;
	}
	this.Controls.AddRange(l);
	this.Controls.AddRange(pic1);
