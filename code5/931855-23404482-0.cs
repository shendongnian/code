    private void BindTable()
            {
                foreach (var item in testList)
                {
                    TableRow NewRow1 = new TableRow();
                    TableCell NewCell1 = new TableCell();
                    CheckBox newCheckBox = new CheckBox();
    
                    NewCell1.Controls.Add(newCheckBox);
                    NewRow1.Cells.Add(NewCell1);
    
                    TableCell NewCell2 = new TableCell();
    
                    Label newLable1 = new Label();
                    newLable1.Text = item.Name;
    
                    NewCell1.Controls.Add(newLable1);
                    NewRow1.Cells.Add(NewCell1);
                    tblLanguages.Rows.Add(NewRow1);
                }
            }
