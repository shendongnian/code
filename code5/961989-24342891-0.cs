	string value = Interaction.InputBox("Enter Array size", "Enter Array size");
	int array = 0;
	if (int.TryParse(value, out array))
	{
		int[] size = new int[array];
		txtOutput.Text = "Numbers: " + "\r\n";
		for (int i = 0; i < size.Length; i++)
		{
			string prompt = Interaction.InputBox("Enter values" + (i + 1), "Enter values");
			int num = 0;
			if (int.TryParse(prompt, out num))
			{
				size[i] = num;
				txtOutput.Text += size[i] + "\t";
			}
		}
	}
