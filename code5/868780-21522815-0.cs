    int countInRow = 3;  // number of barcode in a row on every page.
    
    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
	{        
       panel1_Paint(sender, new PaintEventArgs(e.Graphics, this.ClientRectangle));
       int locCount = SaveBeforePrint.Count;
       for (int i = 0; i < countInRow && i < locCount; i++)
       {
          SaveBeforePrint.RemoveAt(0);        //remove the top element always
       }
       e.HasMorePages = (SaveBeforePrint.Count > 0);
	}
