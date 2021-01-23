		private void Form1_Load(object sender, EventArgs e)
		{
			lblErrorX.Text = null;
			lblErrorY.Text = null;
		}
		private void btnMoveForm_Click(object sender, EventArgs e)
		{
			int x = 0; if (int.TryParse(txtX.Text, out x) == false) { return; }
			int y = 0; if (int.TryParse(txtY.Text, out y) == false) { return; }
			if (x < 0 || y < 0) { return; }
			this.Location = new Point(x, y);
		}
		private void txtX_TextChanged(object sender, EventArgs e)
		{
			int x = 0;
			if (int.TryParse(txtX.Text, out x) == false)
			{ lblErrorX.Text = "X is not an valid integer."; return; }
			if (x < 0) { lblErrorX.Text = "X cannot be negative."; return; }
			lblErrorX.Text = null;
		}
		private void txtY_TextChanged(object sender, EventArgs e)
		{
			int y = 0;
			if (int.TryParse(txtY.Text, out y) == false)
			{ lblErrorY.Text = "Y is not an valid integer."; return; }
			if (y < 0) { lblErrorY.Text = "Y cannot be negative."; return; }
			lblErrorY.Text = null;
		}
