    DataGridView.HitTestInfo myHitTestDown, myHitTestUp;
    int visibleColumnDown, visibleColumnUp;
    private void dataGrid1_MouseUp(object sender, MouseEventArgs e)
    {
        myHitTestUp = dataGrid1.HitTest(e.X, e.Y);
        visibleColumnUp = getVisibleColumn(dataGrid1, e.X);
    }
    private void dataGrid1_MouseDown(object sender, MouseEventArgs e)
    {
        myHitTestDown = dataGrid1.HitTest(e.X, e.Y);
        visibleColumnDown = getVisibleColumn(dataGrid1, e.X);
    }
