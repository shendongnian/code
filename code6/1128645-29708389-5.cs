    int mDwnChar = -1;
    DataGridViewCell lastCell = null;
    private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
        if (dataGridView1.EditingControl == null || cell != lastCell)
        {
            dataGridView1.BeginEdit(false);
            TextBox editor = (TextBox)dataGridView1.EditingControl;
            editor.MouseMove += (ts, te) =>
            {
                if (mDwnChar < 0) return;
                int ms = editor.GetCharIndexFromPosition(te.Location);
                if (ms >= 0 && mDwnChar >=0)
                {
                   editor.SelectionStart = Math.Min(mDwnChar, ms);
                   editor.SelectionLength = Math.Abs(mDwnChar - ms + 1); 
                }
            };
            editor.MouseUp += (ts, te) => { mDwnChar = -1; };
            mDwnChar = editor.GetCharIndexFromPosition(e.Location);
            dataGridView1.Capture = false;
            Timer timer00 = new Timer();
            timer00.Interval = 20;
            timer00.Tick += (ts, te) => { 
                timer00.Stop();
                dataGridView1.BeginEdit(false);
            };
            timer00.Start();
            lastCell = cell;
        }
    }
