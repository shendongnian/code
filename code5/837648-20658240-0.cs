    foreach (GridViewRow myRow in gvSurveyResult.Rows)
    {
        for (int i = 1; i < gvSurveyResult.Columns.Count; i++)
        {
            string labelID = string.Format("lblResult{0}", i);
            Label lblResults = ((Label)ResultsPanel.FindControl(labelID);
            String gvCellText = myRow.Cells[i].Text;
            lblResults.Text = gvCellText;
        }
    }
