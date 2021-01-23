    private void fillByCriteriaToolStripButton_Click(object sender, EventArgs e)
    {
        try
        {
            this.tblPartTableAdapter.FillByCriteria(this.dataSet1.tblPart, partnrToolStripTextBox.Text);
        }
        catch (System.Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);
        }
    }
