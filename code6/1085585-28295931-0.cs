    private void FilesGrid_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == 3)
                {
                    if (!Downloading)
                        GetFile(e.RowIndex);
                  }
            }
