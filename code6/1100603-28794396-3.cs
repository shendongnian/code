    container.Columns.Add(new DataColumn("Banned", typeof(CheckBox)));
        container.Columns.Add(new DataColumn("Admin", typeof(CheckBox)));  
        rowArray[3] = new CheckBox()
            {
                ID = "newID3",
                Checked = true// Or your condition based on myRow.Cells[3].Text
            };
        rowArray[4] = new CheckBox()
        {
            ID = "newID4",
            Checked = true// Or your condition based on myRow.Cells[3].Text
        };
