    private bool isCellClicked = false;
    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
        var hit = dataGridView1.HitTest(e.X, e.Y);
        isCellClicked = (hit.Type == DataGridViewHitTestType.Cell);
    }
    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
        e.Cancel = !isCellClicked;
    }
