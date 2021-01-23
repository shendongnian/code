    TransactionHistoryDialog openTransactionHistoryDialog;
    private void buttonTransferHistory_Click(object sender, EventArgs e)
    {
        if(openTransactionHistoryDialog == null)
        {
            openTransactionHistoryDialog = new TransactionHistoryDialog();
            openTransactionHistoryDialog.updateTextBox();
            openTransactionHistoryDialog.Closed += OnTransactionHistoryDialogClosed;
        }
        openTransactionHistoryDialog.Show();
    }
    private void OnTransactionHistoryDialogClosed(object sender, EventArgs e)
    {
        openTransactionHistoryDialog = null;
    }
