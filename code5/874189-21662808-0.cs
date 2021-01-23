    private void Load_ActionResult_Table()
    {
        ActionResultsTable.ActionResultDataSet actionResultDataSet = ((ActionResultsTable.ActionResultDataSet)(this.FindResource("actionResultDataSet")));
        // Load data into the table ActionResult. You can modify this code as needed.
        ActionResultsTable.ActionResultDataSetTableAdapters.ActionResultTableAdapter actionResultDataSetActionResultTableAdapter = new ActionResultsTable.ActionResultDataSetTableAdapters.ActionResultTableAdapter();
        // Clear the table
        actionResultDataSet.ActionResult.Clear();
        actionResultDataSetActionResultTableAdapter.Fill(actionResultDataSet.ActionResult);
        System.Windows.Data.CollectionViewSource actionResultViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("actionResultViewSource")));
        actionResultViewSource.View.MoveCurrentToFirst();
    }
