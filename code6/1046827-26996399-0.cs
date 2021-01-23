    static string txt = "";
        private void txtFCServerURL_TextChanged(object sender, EventArgs e)
            {
                    DialogResult clearGrid = MessageBox.Show("Changing the text will clear the grid. Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
                    if (clearGrid == DialogResult.Yes)
                    {
                        for (int i = 0; i < dgvGrid.Rows.Count; i++)
                        {
                            dgvGrid.Rows.RemoveAt(0);
                        }
                    }
                    else txtFCServerURL.Text = [TEXT BEFORE CHANGE]
                    txt = txtFCServerURL.Text;
            }
