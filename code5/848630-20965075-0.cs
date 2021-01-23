    void dataGridView_Scroll(object sender, ScrollEventArgs e)
    {
        DataGridView src;
        DataGridView dst1 = null;
        DataGridView dst2 = null;
        src = (DataGridView)sender;
        if (src == dgvSTART)
        {
            dst1 = dgvFilter;
            dst2 = dgvEdit;
        }
        else if (src == dgvFilter)
        {
            dst1 = dgvSTART;
            dst2 = dgvEdit;
        }
        else if (src == dgvEdit)
        {
            dst1 = dgvSTART;
            dst2 = dgvFilter;
        }
        if (dst1 != null && dst2 != null)
        {
            dst1.HorizontalScrollingOffset = dst2.HorizontalScrollingOffset = src.HorizontalScrollingOffset;
           
            dst1.FirstDisplayedScrollingRowIndex = Math.Min(dst1.RowCount - 1, src.FirstDisplayedScrollingRowIndex);
            dst2.FirstDisplayedScrollingRowIndex = Math.Min(dst2.RowCount - 1, src.FirstDisplayedScrollingRowIndex);
        }
    }
