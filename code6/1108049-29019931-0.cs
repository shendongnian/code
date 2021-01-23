		Color _activeColor = Color.Red;
		private void buttons_Click(object sender, EventArgs e)
		{
			foreach (Button btn in this.Controls.OfType<Button>()
						.Where(b => b.BackColor == _activeColor))
			{
				btn.BackColor = SystemColors.Control;
			}
			((Button)sender).BackColor = _activeColor;
		}
