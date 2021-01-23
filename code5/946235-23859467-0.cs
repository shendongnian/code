    Dictionary<string, bool> buttonClicked = new Dictionary<string, bool>();
    private void button123_Clicked(object sender, EventArgs e)
    {
        string buttonName = (sender as Button).Name;
        if (!buttonClicked.ContainsKey(buttonName))
        {
            buttonClicked.Add(buttonName, true);
        }
        if (buttonClicked.Count == 3) button4.Enabled = true;
    }
