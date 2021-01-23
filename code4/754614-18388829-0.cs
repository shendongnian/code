        //if (e.Context == DataGridViewDataErrorContexts.Commit)
        if (e.Context.ToString().Contains(DataGridViewDataErrorContexts.Commit.ToString()))
        {
                  MessageBox.Show("Commit error");
        }
        //if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
        if (e.Context.ToString().Contains(DataGridViewDataErrorContexts.CurrentCellChange.ToString()))
        {
                  MessageBox.Show("Cell change");
        }
        //if (e.Context == DataGridViewDataErrorContexts.Parsing)
        if (e.Context.ToString().Contains(DataGridViewDataErrorContexts.Parsing.ToString()))
        {
                  MessageBox.Show("Parsing error");
        }
        //if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
        if (e.Context.ToString().Contains(DataGridViewDataErrorContexts.LeaveControl.ToString()))
        {
                  MessageBox.Show("Leave control error");
        }
