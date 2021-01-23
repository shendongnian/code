    for (rowCtr = 0; rowCtr < rN; rowCtr+=3)
        {
            // Create a new row and add it to the table.
            TableRow tRow = new TableRow();
            Table1.Rows.Add(tRow);
            int temp = rowCtr;
            for (int i = 0; i<3; i++)
            {
                if(temp >=rN) break;
                // Create a new cell and add it to the row.
                TableCell tCell = new TableCell();
                tRow.Cells.Add(tCell);
                // Add a literal text as control.
                string myStr = test.dsSubjects.Tables[0].Rows[temp]["SubjectName"].ToString();
                tCell.Controls.Add(new LiteralControl(myStr));
                temp++;
                
            }
        }
