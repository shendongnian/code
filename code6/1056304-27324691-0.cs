    private void dtgView_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyValue >= 65 && e.KeyValue <= 90 )
                {
                    searchStrings += e.KeyCode;
                    for (int i = 0; i < dtgView.RowCount; i++)
                    {
                        if (dtgView.Rows[i].Cells[0].Value.ToString().
                            Substring(0, searchStrings.Length) == searchStrings)
                        {
    
                            dtgView.ClearSelection();
                            dtgView.FirstDisplayedScrollingRowIndex = i;
                            dtgView.Rows[i].Selected = true;
                            dtgView.Rows[i].Cells[0].Selected = true;
    
                            break;
                        }
                    }
                }
                
            }
