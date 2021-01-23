	Func<int, ComboBox> createComboBox = i =>
	{
		cb = new ComboBox();
		cb.FormattingEnabled = true;
		cb.Location = new Point(446, 218 + i * 50);
		cb.Name = "name" + i;
		cb.Items.AddRange(new object[]
		{
			"1", "2", "3", "4", "5", "6", "7", "8", "9"
		});
		cb.Size = new Size(45, 21);
		cb.TabIndex = 3;
		return cb;
	};
	comboBoxes =
		Enumerable
			.Range(0, 3)
			.Select(n => createComboBox(n))
			.ToList();
			
	comboBoxes
		.ForEach(cb => 
			grpAvailability.Controls.Add(cb));
