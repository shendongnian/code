    public IEnumerable<ListBox> ListBoxes
    {
        get
        {
            return Controls.Where(c => c.Tag == "List").Cast<ListBox>();
        }
    }
