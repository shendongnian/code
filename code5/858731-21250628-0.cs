    private void PrintButton_Click(object sender, EventArgs e)
    {
       for(int j =0 ; j < SerialNumberList.Count ; j++)
       {
    		BarcodeLib.TYPE barcodetype1 = BarcodeLib.TYPE.CODE39;
    		BarcodeLib.Barcode bar1 = new BarcodeLib.Barcode();
    		bar1.IncludeLabel = true;
    		var pictureBox = new PictureBox();
    		pictureBox.Image = bar1.Encode(barcodetype1 ,SerialNumberList[j]);
    		PictureBoxList.Add(pictureBox);
    		printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
    		printDocument1.Print();
       }
    }
