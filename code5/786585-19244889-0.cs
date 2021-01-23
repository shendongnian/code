	protected Dictionary<string, string> dict = new Dictionary<string, string>();
	public MyClass()
	{
		dict.Add("rad1", "value1");
		dict.Add("rad2", "value2");
		dict.Add("rad3", "value3");
		dict.Add("rad4", "value4");
	}
	protected void buttSubmit_Click(object sender, EventArgs e)
	{    
		string vValue;
		dict.TryGetValue(RadioButtonList.SelectedValue, out vValue);
		submitVote(vValue);
	}
