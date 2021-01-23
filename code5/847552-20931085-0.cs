	var f = 24;
	var j = 25;
	
	var textBoxes =
		Enumerable
			.Range(0, listView1.Items.Count)
			.Select(gg =>
			{
				j = f + j;
				var txtb = new TextBox();
				txtb.Name = String.Format("tboxl1{0}", gg);
				txtb.Location = new Point(330, j);
				txtb.Visible = true;
				txtb.Enabled = true;
				txtb.Font = new Font(txtb.Font.FontFamily, 12);
				return txtb;
			})
			.ToList();
		
	textBoxes.ForEach(txtb => groupBox2.Controls.Add(txtb));
