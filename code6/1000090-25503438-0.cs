    private void Event(object sender, MouseEventArgs e)
    {
        HitTestResult hitTestResult = 
            VisualTreeHelper.HitTest(m_DataGrid, e.GetPosition(m_DataGrid));
        DataGridRow dataGridRow = hitTestResult.VisualHit.GetParentOfType<DataGridRow>();
        int index = dataGridRow.GetIndex();
    }
