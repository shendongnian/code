    protected void grid2_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
            if (e.Column.UniqueName == "Description")
            {
                GridBoundColumn bCol = e.Column as GridBoundColumn;
                if (bCol != null)
                {
                    TemplateAutoCompleteFilter template = new TemplateAutoCompleteFilter(
                                       RadComboBoxFilter.Contains, data.Select(r => r.Name).ToArray());
                    bCol.FilterTemplate = template;
                }
            }
        }
