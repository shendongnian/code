    private void Bu_Submite_Click(object sender, EventArgs e)
            {
    
                foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
                {
                    if (!oneCell.Selected)
                    {
                        String Date = monthCalendarX1.GetSelectedDateInPersianDateTime().ToShortDateString();
                        dataGridView1.Rows.Add(Date);
                    }
    
                    else
                    {                   
                         if (oneCell.Selected)
                            dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                    }
                }
            }
