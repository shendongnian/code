       private void radListView1_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
       {
        if ((e.CellElement).Data.HeaderText == "ID")
        {
            if ((e.CellElement is DetailListViewDataCellElement))
            {
                e.CellElement.TextAlignment = ContentAlignment.TopRight;
            }
        }
        if ((e.CellElement).Data.HeaderText == "Name")
        {
            if ((e.CellElement is DetailListViewDataCellElement))
            {
                e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
            }
        //end so on
        }
    }
