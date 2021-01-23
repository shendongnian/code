    private static readonly Dictionary<string, string> dict
          = new Dictionary<string, string> {
        {"rad1", "value1"},
        {"rad2", "value2"},
        {"rad3", "value3"},
        {"rad4", "value4"},
    };
    protected void buttSubmit_Click(object sender, EventArgs e)
    {
        string value;
        if(dict.TryGetValue(RadioButtonList.SelectedValue, out value))
        {
            submitVote(value);
        }
    }
