    private Rectangle GetCellRectangle(int columnIndex, int rowIndex)
            {
                Rectangle selRect = new Rectangle(0, 0, 0, 0);
                selRect.X = RowHeadersWidth + 1;
                for (int i = FirstDisplayedScrollingColumnIndex; i < columnIndex; i++)
                {
                    selRect.X += Columns[i].Width;
                }
                selRect.X -= FirstDisplayedScrollingColumnHiddenWidth;
                selRect.Y = ColumnHeadersHeight + 1;
                for (int i = FirstDisplayedScrollingRowIndex; i < rowIndex; i++)
                {
                    selRect.Y += Rows[i].Height;
                }
                selRect.Width = Rows[rowIndex].Cells[columnIndex].Size.Width;
                selRect.Height = Rows[rowIndex].Cells[columnIndex].Size.Height;
                return selRect;
            }
