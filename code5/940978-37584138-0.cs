    private void Form1_Load(object sender, EventArgs e)
    {
        //Create datagridview and button below it.
        DataGridView dgv = new DataGridView();
        dgv.Columns.Add("Column1","Column1");
        dgv.Rows.Add(2);
        dgv.AllowUserToAddRows = false;
        this.Controls.Add(dgv);
    
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        int tw;
        tw = dgv.Columns.GetColumnsWidth(DataGridViewElementStates.None) + dgv.RowHeadersWidth + 2;
        dgv.Width = tw;
        // the cellleave, is done before the autoresize.
        // but performing a button click, that triggers a cell autoresize!
        //performing a click to a button added to the form..does the autoresize.
        // so the resie has to be done after the click... either in the click code, or in the celleave procedure after the performclick.
        
        Button by = new Button();
        this.Controls.Add(by); // necessary for the dgv to resize
        // but doesn't need the code to necessarily be within the click.
        by.Click += (object ssender, EventArgs ee) => { };
        dgv.CellEndEdit += (object ssender, DataGridViewCellEventArgs ee) => {
            by.PerformClick();
            tw = dgv.Columns.GetColumnsWidth(DataGridViewElementStates.None) + dgv.RowHeadersWidth + 2;
            dgv.Width = tw;
        };
    }
