    public PromptScreen()
    {
        InitializeComponent();
        this.Icon = Properties.Resources.TDXm;
        string[] checkByDefault = new[] { "CGM's", "Database" };
        for (int i = 0; i < cLbFiles.Items.Count; i++)
        {
            string itemString = cLbFiles.Items[i].ToString();
            dictionary.Add(itemString, checkByDefault.Contains(itemString) ? CheckState.Checked :  CheckState.Unchecked);
    }
