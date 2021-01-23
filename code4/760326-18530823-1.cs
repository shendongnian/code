    protected void xyz()
    {
        ((DataControlField)youGridView.Columns
                .Cast<DataControlField>()
                .Where(fld => fld.HeaderText == "your header text")
                .SingleOrDefault()).Visible = false;
    }
