    void LockCols(int istart, int iend, bool isReadOnly)
    {
        for (int idx = istart; idx < iend; idx++)
        {
            if (isReadOnly)
            {
                 dgv.Columns[idx].ReadOnly = isReadOnly;
                 dgv.Columns[idx].HeaderText = dgv.Columns[idx].Name + "_" + "ReadOnly";
            }
            else
            {
                 dgv.Columns[idx].ReadOnly = isReadOnly;
                 dgv.Columns[idx].HeaderText = dgv.Columns[idx].Name + "_" + "Not_ReadOnly";
            }
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();
        LockCols(0, dgv.Columns.Count / 2, true);
        LockCols(dgv.Columns.Count / 2 + 1, dgv.Columns.Count, false);
        sw.Stop();
        MessageBox.Show(sw.Elapsed.ToString());
    }
