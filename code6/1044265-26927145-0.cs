    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hti = dataGridView1.HitTest(e.X, e.Y);
                    if (hti.RowIndex >= 0)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.CurrentCell = dataGridView1[hti.ColumnIndex, hti.RowIndex];
                    }
                }
            }
