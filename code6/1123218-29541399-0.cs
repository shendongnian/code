    for (int i = 1; i <= rowCount - 1; i++)
            {
                if (tableLayoutPanel2.GetControlFromPosition(1, i).Text != "✔")
                {
                    insertRow = i;
                    break;
                }
            }
            //Add Row to table
            tableLayoutPanel2.RowCount++;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29));
            //Insert member
            tableLayoutPanel2.Controls.Add(new Label() { Text = Name.Text, TextAlign = ContentAlignment.MiddleCenter, Anchor = AnchorStyles.None, AutoSize = false }, 0, insertRow);
