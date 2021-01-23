    List<int> buttonSubfixId = new List<int>()
    {
        1,
        2
    };
    
    foreach (var id in buttonSubfixId)
    {
        var controls = this.Controls.Find("button" + id.ToString(), true).OfType<Button>();
        
        if (controls.Count()>0)
        {
            foreach (var button in controls)
            {
                button.Enabled = false;
            }
        }
    }
