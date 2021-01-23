	static float[] patSolid = new float[] { 10 };
	static float[] patDash = new float[] { 10, 10 };
	static float[] patDot = new float[] { 3, 5 };
	private void RedrawFromGrid(Graphics g)
	{
		float X1, Y1, X2, Y2;
		for (int i = 0; i < dataGridView1.Rows.Count; i++)
		{
			var cells = dataGridView1.Rows[i].Cells;
			
			if (!float.TryParse(cells[0].Value.ToString(), out X1) ||
				!float.TryParse(cells[1].Value.ToString(), out Y1) ||
				!float.TryParse(cells[2].Value.ToString(), out X2) ||
				!float.TryParse(cells[2].Value.ToString(), out X2)
			)
				continue;
			
			var style = cells[5].Value.ToString();p
			float[] pattern = patSolid;
			if (style == "Dash")
				pattern = patDash;
			else if (style == "Dot")
				pattern = patDot;
			
			using (var pen = new Pen(cells[4].Style.BackColor))
			{
				pen.DashPattern = pattern;
				g.DrawLine(pen, X1, Y1, X2, Y2);
			}
		}
	}
