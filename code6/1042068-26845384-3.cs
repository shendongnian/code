    // step 1
    Document document = new Document(PageSize.LEGAL.rotate());
    // step 2
    PdfWriter writer = PdfWriter.getInstance(document, new FileOutputStream(file));
    // step 3
    document.open();
    // step 4
    Rectangle left = new Rectangle(36, 36, 486, 586);
    Rectangle right = new Rectangle(522, 36, 972, 586);
    ColumnText column = new ColumnText(writer.getDirectContent());
    column.setSimpleColumn(left);
    boolean leftside = true;
    int status = ColumnText.START_COLUMN;
    for (Element e : elements) {
        if (ColumnText.isAllowedElement(e)) {
            column.addElement(e);
            status = column.go();
            while (ColumnText.hasMoreText(status)) {
                if (leftside) {
                    leftside = false;
                    column.setSimpleColumn(right);
                }
                else {
                    document.newPage();
                    leftside = true;
                    column.setSimpleColumn(left);
                }
                status = column.go();
            }
        }
    }
    // step 5
    document.close();
