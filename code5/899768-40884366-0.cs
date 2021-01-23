    private void AddItem(string address, string contactNum, string email )
        {
            //get a reference to the previous existent 
            RowStyle temp = panel.RowStyles[panel.RowCount - 1];
            //increase panel rows count by one
            panel.RowCount++;
            //add a new RowStyle as a copy of the previous one
            panel.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            //add your three controls
            panel.Controls.Add(new Label() {Text = address}, 0, panel.RowCount - 1);
            panel.Controls.Add(new Label() { Text = contactNum }, 1, panel.RowCount - 1);
            panel.Controls.Add(new Label() { Text = email }, 2, panel.RowCount - 1);
        }
