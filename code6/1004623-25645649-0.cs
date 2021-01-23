	for(int i = 0; i < CheckList.Count; i++)
	{
		TheTypeOfWhateverIsInCheckList c = CheckList[i];
		CheckBox cb = new CheckBox();
		cb.Text = c.WhateverPropertyIsAString;
		cb.Left = 50 + (i * 50);
		this.Controls.Add(cb);
	}
