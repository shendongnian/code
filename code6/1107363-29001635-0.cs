        pos = dgv.CurrentCell.RowIndex;
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (inc != MaxRows + 1)
            {
                inc = 0;
                MaxRows = 0;
                fill_textBoxes();
                if (pos < dgv.RowCount)
                {
                    dgv.Rows[pos].Selected = false;
                    dgv.Rows[pos = 0].Selected = true;
                }
            }           
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (inc != MaxRows + 1)
                {
                    inc--;
                    fill_textBoxes();
                    if (pos < dgv.RowCount)
                    {
                        dgv.Rows[pos].Selected = false;
                        dgv.Rows[--pos].Selected = true;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                DialogResult dlgResult;
                dlgResult = MessageBox.Show(
                        "First record",
                        "Records",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (inc != MaxRows - 1)
            {
                inc++;
                fill_textBoxes();
                if (pos < dgv.RowCount)
                {
                    dgv.Rows[pos].Selected = false;
                    dgv.Rows[++pos].Selected = true;
                }
            }
            else
                MessageBox.Show("No more records");
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            if (inc != MaxRows - 1)
            {
                inc = MaxRows - 1;
                fill_textBoxes();
                if (pos < dgv.RowCount)
                {
                    dgv.Rows[pos].Selected = false;
                    dgv.Rows[pos = MaxRows - 1].Selected = true;
                }
            }
        }
