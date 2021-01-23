    private void buttonPrintPreview_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printDialog = new PrintPreviewDialog();
            printDialog.Document = yourDocument;
            yourDocument.EndPrint += doc_EndPrint; // Subscribe to EndPrint event of your document here.
            printDialog.ShowDialog();
        }
        void doc_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (e.PrintAction == System.Drawing.Printing.PrintAction.PrintToPrinter)
            {
                // Printing to the printer!
            }
            else if (e.PrintAction == System.Drawing.Printing.PrintAction.PrintToPreview)
            {
                // Printing to the preview dialog!
            }
        }
