        dgv.SortCompare += new DataGridViewSortCompareEventHandler(OnDataGridViewSortCompare);
        void OnDataGridViewSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            int retVal = String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());
            //They are ==, Compare by next column
            if (retVal == 0)
            {
                retVal = String.Compare(dgv[e.Column.Index + 1, e.RowIndex1].Value.ToString(),
                dgv[e.Column.Index + 1, e.RowIndex2].Value.ToString()) * -1; //Multiply by -1 to flip the ASC sort to DESC
            }
            e.SortResult = retVal;
            e.Handled = true;
        }
