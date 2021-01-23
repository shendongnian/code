    public void test()
    {
        HtmlTableRow row = new HtmlTableRow();
        HtmlTableCell cell = new HtmlTableCell();
    
    
        for (i = 0; i <= 10; i++) {
            row = new HtmlTableRow();
            for (j = 0; j <= 3; j++) {
                cell = new HtmlTableCell();
                cell.InnerText = "m";
                LinkButton btn1 = new LinkButton();
                btn1.ID = i;
                // Add EventHandler for click events
                btn1.Click += new EventHandler(LinkButton_OnClick);
    
                cell.Controls.Add(btn1);
                row.Cells.Add(cell);
            }
            tableContent.Rows.Add(row);
        }
    }
