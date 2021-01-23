            int _row = 1;
            int _cell = 0;
            string[] arr = new string[6] { "ID", import.oCultivationPlan.iID.ToString(), "Description", import.oCultivationPlan.sDescription.ToString(), "DateCreated", import.oCultivationPlan.dDateCreated.ToString() };
            for (; _row <= 3; _row++)
            {
                TableRow tblRow = new TableRow();
                for (; _cell < _row * 2; _cell++)
                {
                    TableCell tblc = new TableCell();
                    tblc.Controls.Add(new LiteralControl(arr[_cell]));
                    tblRow.Controls.Add(tblc);
                }
                tblImportPreview.Controls.Add(tblRow);
            }
