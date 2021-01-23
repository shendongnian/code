    public class MyTreeViewItem : TreeViewItem
    {
        public MyTreeViewItem()
        {
            this.MouseRightButtonDown += MyTreeViewItem_MouseRightButtonDown ;
        }
    
        void MyTreeViewItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            if (sender as MyTreeViewItem != null)
            {
                (sender as MyTreeViewItem).IsSelected = true;
                e.Handled = true;
            }
        }
    }
