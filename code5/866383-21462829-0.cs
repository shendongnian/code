    private void ggcResult_DataSourceChanged(object sender, EventArgs e)
    {
        if (ggcResult.TableDescriptor.Columns.Contains("MY_COL"))
        {
            var col = ggcResult.TableDescriptor.Columns["MY_COL"];
            // setting the type for corresponding format --------------
            col.Appearance.AnyCell.CellValueType = typeof(int);
            col.Appearance.AnyCell.Format = "D3";
        }
    }
