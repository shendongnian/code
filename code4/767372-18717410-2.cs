    private void Button1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
	dynamic btn = (Button)sender;
	dynamic drawBrush = new SolidBrush(btn.ForeColor);
	dynamic sf = new StringFormat {
		Alignment = StringAlignment.Center,
		LineAlignment = StringAlignment.Center };
	Button1.Text = string.Empty;
	e.Graphics.DrawString("Button1", btn.Font, drawBrush, e.ClipRectangle, sf);
	drawBrush.Dispose();
	sf.Dispose();
    }
