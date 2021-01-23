    private int status = ColumnText.START_COLUMN;
    private float y_position = 0;
    public void addTable(Document document, PdfContentByte canvas, PdfPTable table)
        throws DocumentException {
        Rectangle pagedimension = new Rectangle(36, 36, 559, 806);
        drawColumnText(document, canvas, pagedimension, table, true);
        Rectangle rect;
        if (ColumnText.hasMoreText(status)) {
            rect = pagedimension;
        }
        else {
            rect = new Rectangle(36, 36, 559, 806 - ((y_position - 36) / 2));
        }
        drawColumnText(document, canvas, rect, table, false);
    }
 
    public void drawColumnText(Document document, PdfContentByte canvas, Rectangle rect, PdfPTable table, boolean simulate)
        throws DocumentException {
        ColumnText ct = new ColumnText(canvas);
        ct.setSimpleColumn(rect);
        ct.addElement(table);
        status = ct.go(simulate);
        y_position = ct.getYLine();
        while (!simulate && ColumnText.hasMoreText(status)) {
            document.newPage();
            ct.setSimpleColumn(rect);
            status = ct.go(simulate);
        }
    }
