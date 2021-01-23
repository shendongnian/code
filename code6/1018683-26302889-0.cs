    bool Isfirstpage = true;
    
    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
    ///.....
    
       if (count == 0 && Isfirstpage)
       {
         yPosition = 590;
         topMargin = 590;
         Isfirstpage = false;
       }
     
    ///....
