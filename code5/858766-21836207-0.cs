    void RowValueSet(DataGridViewRow dgr)
    {
        dgr.Cells["StudentZero"].Value = ss.Where(w => w.MarksheetMarks == "0").Count();
        if (ss.Count() != 0)
            dgr.Cells["StudentISEmpty"].Value = Convert.ToInt16(lblTotlatStudent1.Text) - ss.Count();
        else
            dgr.Cells["StudentISEmpty"].Value = 0;
        dgr.Cells["StudentEntry"].Value = ss.Count();
    }
