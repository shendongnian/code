    private bool allowdrag;
    private void lv_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ListView listView = sender as ListView;
        allowdrag = e.GetPosition(sender).X < listView.ActualWidth - SystemParameters.VerticalScrollBarWidth & e.GetPosition(sender).Y < listView.ActualHeight - SystemParameters.HorizontalScrollBarHeight;
    }
    private void lv_MouseMove(object sender, MouseEventArgs e)
    {
        ListView listView = sender as ListView;
        if (e.LeftButton == MouseButtonState.Pressed & listView.SelectedItem != null & allowdrag) {
            clsAttribute obj = (clsAttribute)listView.SelectedItem;
            DataObject dragData = new DataObject("clsAttribute", obj);
            DragDrop.DoDragDrop(listView, dragData, DragDropEffects.Copy);
        }
    }
