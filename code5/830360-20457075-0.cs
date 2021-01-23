    bool _Double = false;
    private void dataGridView1_DoubleClick(object sender, EventArgs e)
    {
        _Double = true;
    }
    private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            ///
        }
        else if (_Double) {
        }
    }
