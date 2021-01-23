    public partial class MainWindow : Window
    {
        private const int dragMargin = 10;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ListBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed || list.SelectedItem == null)
                return;
            if (e.MouseDevice.DirectlyOver != null)
            {
                DragDrop.DoDragDrop(list, list.SelectedItem, DragDropEffects.All);
            }
        }
        private void list_Drop(object sender, DragEventArgs e)
        {
            var source = sender as ListBox;
            if (source == null)
                return;
            var item = e.Data.GetData(typeof (ContentControl));
            if (item == null)
                return;
            source.Items.Remove(item);
            var listAsTarget = sender as ListBox;
            if (listAsTarget == null)
                return;
            var mouseDirectitem = e.OriginalSource;
            var listItem = VisualFindParentFromType<ListBoxItem>(mouseDirectitem as UIElement);
            
            if (listItem == null)
            {
                listAsTarget.Items.Insert(0, item);
                return;
            }
            var insertBefore = true;
            var pointReletiveItem = e.GetPosition(listItem);
            Debug.WriteLine("Item Height: {0}", listItem.ActualHeight);
            Debug.WriteLine("Y: {0}", pointReletiveItem.Y);
            if (pointReletiveItem.Y > listItem.ActualHeight / 2)
                insertBefore = false;
            var index = listAsTarget.Items.IndexOf(listItem.Content);
            if (index >= 0)
            {
                listAsTarget.Items.Insert(insertBefore ? index : index + 1, item);
                return;
            }
            listAsTarget.Items.Add(item);
        }
        private T VisualFindParentFromType<T>(DependencyObject element) where T : UIElement
        {
            if (element == null)
                return default(T);
            if (element is T)
                return (T)element;
            return VisualFindParentFromType<T>(VisualTreeHelper.GetParent(element));
        }
        private T FindChildrenFromType<T>(DependencyObject element) where T : UIElement
        {
            if (element == null)
                return default(T);
            if (element is T)
                return (T) element;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                var result = FindChildrenFromType<T>(VisualTreeHelper.GetChild(element, i));
                if (!Equals(default(T), result))
                    return result;
            }
            return default(T);
        }
        private void list_DragOver(object sender, DragEventArgs e)
        {
            var source = e.Source as ListBox;
            if (source == null)
                return;
            var point = e.GetPosition(source);
            var scrollViewer = FindChildrenFromType<ScrollViewer>(source);
            if (scrollViewer == null)
                return;
            if (point.Y < dragMargin)
            {
                scrollViewer.LineUp();
            }
            else if (point.Y > Math.Abs(source.ActualHeight - dragMargin))
            {
                scrollViewer.LineDown();
            }
        }
    }
