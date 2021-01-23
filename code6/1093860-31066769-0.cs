            // Used for the appearence of the cell, it doesn't mean that there is a correlation between the cell and the column (see below ***)
            tbCell.Style.ForeColor = Color.Blue;
            tbCol.CellTemplate = tbCell;
            tbCol.Name = "qtySelect";
            tbCol.HeaderText = "Header";
            int colIndex = gridProduct.Columns.Add(tbCol);
            const int rowNumber = 0;    // define which row you want
            //Pay attention that you may need to add rows before writting to the cell
            //const int rowNumber = 1;
            //gridProduct.Rows.Add();            
            gridProduct.Rows[rowNumber].Cells[colIndex].Value = "Value for cell";
            //*** If you want to work with the cell itself, you first need to get a reference to it
            //tbCell = gridProduct.Rows[0].Cells[0] as DataGridViewTextBoxCell;
            //tbCell.Value = "1"; // and then you can overwrite the value
