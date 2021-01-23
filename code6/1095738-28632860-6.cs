    private void cb_print_Click(object sender, EventArgs e)
    {
        totalNumber = range();
        try
        {
            if (DBC.State == ConnectionState.Open)
            {
                pagesPrinted = 0;
                printPreviewDlg.Document = printDocument1;
                printPreviewDlg.ShowDialog();
            }
        } catch (Exception q) { MessageBox.Show("" + q); }
        DR.Dispose();
    }
