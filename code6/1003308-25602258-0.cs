    tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100))
    tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100))
    tableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100))
    CType(xPage.Controls(0), TableLayoutPanel).ColumnCount =3
    
    TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 80.0F))
    TableLayoutPanel.RowCount +=1
    
     TableLayoutPanel).Controls.Add(label1, 0, 0)
     TableLayoutPanel).Controls.Add(radiobutton, 1, 0)
     TableLayoutPanel).Controls.Add(checkbox,2, 0)
