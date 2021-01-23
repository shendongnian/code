    // Column definition
    float[][] x = {
        new float[] { document.Left, document.Left + 380 },
        new float[] { document.Right - 380, document.Right }
    };
    column.AddElement(yourTable);
    int count = 0; // can be 0 or 1 if your page is divided in 2 parts
    float height = 0;
    int status = 0;
    // render the column as long as it has content
    while (ColumnText.HasMoreText(status)) {
        // add the top-level header to each new page
        if (count == 0) {
             AddFooterTable(); // for you to implement to add a footer
             height = AddHeaderTable(); // for you to implement to add a header
        }
        // set the dimensions of the current column
        column.SetSimpleColumn(
            x[count][0], document.Bottom,
            x[count][1], document.Top - height - 10
        );
        // render as much content as possible
        status = column.Go();
        // go to a new page if you've reached the last column
        if (++count > 1) {
            count = 0;
            document.NewPage();
        }
    }
    document.NewPage();
