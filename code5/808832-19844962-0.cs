    public SelectRouteSegmentDialog()
    {
        InitializeComponent();
        LineComboBox.Items.Filter += FilterPredicate;
    }
    private bool FilterPredicate(object obj)
    {
        Line line = obj as Line;
        if (string.IsNullOrEmpty(LineComboBox.Text)) return true;
        if (line.SearchText != null)
        {
            if (line.SearchText.IndexOf(LineComboBox.Text, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                return true;
            }
            return false;
        }
        else
        {
            //if the string is null, return false
            return false;
        }
    }
    private void combobox_KeyUp(object sender, KeyEventArgs e)
    {
        if ((e.Key == Key.Enter) || (e.Key == Key.Tab) || (e.Key == Key.Return))
        {
            //Formatting options
            LineComboBox.Items.Filter = null;
        }
        else if ((e.Key == Key.Down) || (e.Key == Key.Up))
        {
            LineComboBox.IsDropDownOpen = true;
        }
        else
        {
            LineComboBox.IsDropDownOpen = true;
            LineComboBox.Items.Filter += this.FilterPredicate;
        }
    }
