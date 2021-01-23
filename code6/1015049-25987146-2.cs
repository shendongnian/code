    private int sumErrors;
    private int sumTests;
    private int sumTestErrors;
    private void dxgErrorGrid_CustomSummary(object sender, CustomSummaryEventArgs e)
    {
        if (!e.IsGroupSummary)
            return;
        switch (e.SummaryProcess)
        {
            case CustomSummaryProcess.Start:
                sumErrors = 0;
                sumTests = 0;
                sumTestErrors = 0;
                break;
            case CustomSummaryProcess.Calculate:
                var testError = Convert.ToInt32(((clsErrorData)e.Row).TestErrors);
                sumTests += ((clsErrorData)e.Row).TestAmount;
                sumErrors += testError;
                sumTestErrors += testError != 128 ? testError : 0;
                break;
            case CustomSummaryProcess.Finalize:
                var summary = e.Item as GridSummaryItem;
                if (summary == null || summary.Tag == null)
                    return;
                switch (summary.Tag.ToString())
                {
                    case "Custom0":
                        e.TotalValue = (decimal)sumErrors / sumTests;
                        break;
                    case "Custom1":
                        e.TotalValue = sumTestErrors;
                        break;
                }
                break;
        }
    }
