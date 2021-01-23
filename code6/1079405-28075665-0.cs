    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int year = DateTime.Now.Year;
            for (int i = 0; i < 5; i ++)
            {
                string item = (year - i).ToString();
                YearListBox.Items.Add(new ListItem(item, item));
            }
        }
    }
    
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        IList<string> selectedValues = YearListBox.Items.Cast<ListItem>()
            .Where(x => x.Selected)
            .Select(x => x.Value)
            .ToList();
    }
