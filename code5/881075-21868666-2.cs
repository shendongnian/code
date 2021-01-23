    void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 0)
            {
                if ( int.Parse(e.CellValue1.ToString()) > int.Parse(e.CellValue2.ToString()))
                {
                    e.SortResult = 1;
                }
                else if (int.Parse(e.CellValue1.ToString()) < int.Parse(e.CellValue2.ToString()))
                {
                    e.SortResult = -1;
                }
                else
                {
                    e.SortResult = 0;
                }
                e.Handled = true;
            }
        }   
