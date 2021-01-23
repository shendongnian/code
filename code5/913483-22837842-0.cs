    foreach (UITextField item in TextFieldList) {
		if (item.Text == "") {
			item.BackgroundColor = UIColor.Red;
		} else {
			Console.WriteLine (item.Text);
		}
	}
