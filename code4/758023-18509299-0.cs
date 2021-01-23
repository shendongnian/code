    PdfPTable DummyTable = new PdfPTable(2);
    //Here the floatSpace value changes according to the lftBulletIndent values
    float[] headerwidths = { 2f + floatSpace, 98f - floatSpace};
    DummyTable.SetWidths(headerwidths);
    
    Pcell = new PdfPCell();
    Pcell.Border = Rectangle.NO_BORDER;
    DummyTable.AddCell(Pcell);
    
                                  
    Pcell = new PdfPCell();
    Pcell.AddElement(list);
    Pcell.Border = Rectangle.NO_BORDER;
    DummyTable.AddCell(Pcell);
                                 
    pobjTable.AddCell(DummyTable);//Inserting a new table here
    pobjTable.AddCell("");
