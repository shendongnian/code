    private void printButton_Click(object sender, EventArgs e)
    {
        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
        PrintDialog printdlg = new PrintDialog();
        PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
        
        // preview the assigned document or you can create a different previewButton for it
        printPrvDlg.Document = pd;
        printPrvDlg.ShowDialog(); // this shows the preview and then show the Printer Dlg below
        printdlg.Document = pd;
        if (printdlg.ShowDialog() == DialogResult.OK)
        {
            pd.Print();
        }
    }
