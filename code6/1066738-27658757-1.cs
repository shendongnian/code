    FrmFilterSearch frmFilters = new FrmFilterSearch();
    public YourConstructor()
    {
        frmFilters.SetDesktopLocation(Location.X + Size.Width, Location.Y);
    }
    private void FilterButton_Click(object sender, EventArgs e)
    {
        if (!Filters)
        {
            Filters = true;
            btn_show_filters.Text = "< Hide filters";
            frmFilters.Show();
        }
        else
        {
            Filters = false;
            btn_show_filters.Text = "Show filters >";
            frmFilters.Hide();
        }
    }
