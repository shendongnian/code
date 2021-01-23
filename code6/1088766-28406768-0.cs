    private void source_CurrentItemChanged(object sender, EventArgs e)
    {
        System.Data.DataRowView view = this.source.Current as System.Data.DataRowView;
        if (view != null)
        {
            System.Diagnostics.Debug.WriteLine(view[0].ToString());
        }
    }
