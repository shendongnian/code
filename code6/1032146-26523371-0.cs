	foreach (XmlNode xn in list1)
	{
		string name = xn["BinCode"].InnerText;
		disGood.Text = name;
		disOccupied.Text = name.Length.ToString();
		foreach (char c in name) // You can iterate through a string.
		{
			TextBox theTextBox = new TextBox();
			if (c == '1') // Compare characters.
			{
				theTextBox.BackColor = Color.Yellow;
			}
			Controls.Add(theTextBox); // Add the textbox to the controls collection of this parent control.
			disGood.Text = c.ToString(); // This will only show the last charachter. Is this as needed?
		}
	}
