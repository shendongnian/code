    private int GetColumnOffset(int offset)
        {
            int start = 0, end = 0;
            DataGridViewColumnCollection Columns = dgvBudgetPeriods.Columns;
            foreach (var column in Columns.Cast<DataGridViewColumn>().Where(c => !c.Frozen))
            {
                end = start + column.Width;
                if (start <= offset && offset < end)
                {
                    break;
                }
                start = end;
            }
            return start == offset ? offset : end;
        }
