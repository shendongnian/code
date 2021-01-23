	using(StreamWriter wr = new StreamWriter(file))
	{
		wr.WriteLine(txtName.Text);
		wr.WriteLine(txtOrderRef.Text);
		foreach (var control in Panel1.Controls.OfType<TextBox>())
		{
			wr.WriteLine(control.Text);
		}
	}
