    TransactionHistoryDialog openTransactionHistoryDialog;
    private void buttonTransferHistory_Click(object sender, EventArgs e)
    {
        if(TransactionHistoryDialog == null)
        {
            openTransactionHistoryDialog = new TransactionHistoryDialog();
            openTransactionHistoryDialog.updateTextBox();
        }
        openTransactionHistoryDialog.Show();
    }
