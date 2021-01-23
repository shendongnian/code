    public static class DragAndDropManager
    {
        #region IsDragSource Attached Property
        public static readonly DependencyProperty IsDragSourceProperty
            = DependencyProperty.RegisterAttached("IsDragSource",typeof(bool),typeof(DragAndDropManager),new PropertyMetadata(IsDragSourceChanged));
        public static void SetIsDragSource(DependencyObject d, bool value)
        {
            d.SetValue(IsDragSourceProperty, true);
        }
        public static bool GetIsDragSource(DependencyObject d)
        {
            return (bool)d.GetValue(IsDragSourceProperty);
        }
        private static void IsDragSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as FrameworkElement;
            if (element == null)
                return;
            element.PreviewMouseMove += OnPreviewMouseMove;
        }
        private static void OnPreviewMouseMove(object sender, MouseEventArgs args)
        {
            var element = (FrameworkElement)sender;
            var dragSource = args.OriginalSource as FrameworkElement;
            if (args.LeftButton != MouseButtonState.Pressed
                || dragSource == null
                || dragSource.DataContext == null)
                return;
            var dragData = new DataObject(dragSource.DataContext);
            DragDrop.DoDragDrop(element, dragData, DragDropEffects.Move);
        }
        #endregion
        #region IsDropTarget Attached Property
        public static readonly DependencyProperty IsDropTargetProperty
            = DependencyProperty.RegisterAttached("IsDropTarget",typeof(bool),typeof(DragAndDropManager),new PropertyMetadata(IsDropTargetChanged));
        public static void SetIsDropTarget(DependencyObject d, bool value)
        {
            d.SetValue(IsDropTargetProperty, true);
        }
        public static bool GetIsDropTarget(DependencyObject d)
        {
            return (bool)d.GetValue(IsDropTargetProperty);
        }
        private static void IsDropTargetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as FrameworkElement;
            if (element == null)
                return;
            element.AllowDrop = true;
            element.DragOver += OnDragOver;
            element.Drop += OnDrop;
        }
        private static void OnDragOver(object sender, DragEventArgs e)
        {
            if (e.Data == null || e.Handled)
            {
                e.Effects = DragDropEffects.None;
                return;
            }
            var element = (FrameworkElement)sender;
            var command = GetDropCommand(element);
            if (command == null)
                return;
            var dataFormats = e.Data.GetFormats();
            if (dataFormats==null)
                return;
            var dragAndDropInfo = new DragAndDropInfo(element.DataContext,
                                e.Data.GetData(dataFormats.FirstOrDefault()));
            var canDrop = dragAndDropInfo.DroppedItem != dragAndDropInfo.SourceItem
                            && command.CanExecute(dragAndDropInfo);
            e.Handled = true;
            e.Effects = canDrop
                        ? e.Effects = DragDropEffects.All
                        : DragDropEffects.None;
        }
        private static void OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null || e.Handled)
                return;
            var element = (FrameworkElement)sender;
            var command = GetDropCommand(element);
            if (command == null)
                return;
            var dataFormats = e.Data.GetFormats();
            if (dataFormats == null)
                return;
            var dragAndDropInfo = new DragAndDropInfo(element.DataContext,
                                e.Data.GetData(dataFormats.FirstOrDefault()));
            
            var canDrop = dragAndDropInfo.DroppedItem != dragAndDropInfo.SourceItem
                           && command.CanExecute(dragAndDropInfo);
            if (canDrop)
            {
                command.Execute(dragAndDropInfo);
            }
            e.Handled = true;
        }
        #endregion
        #region DropCommand Attached Property
        public static readonly DependencyProperty DropCommandProperty
            = DependencyProperty.RegisterAttached("DropCommand",typeof(ICommand),typeof(DragAndDropManager),new PropertyMetadata(DropCommandProperty));
        public static void SetDropCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(DropCommandProperty, value);
        }
        public static ICommand GetDropCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(DropCommandProperty);
        }
        #endregion
    }
    
    public class DragAndDropInfo
    {
        public object SourceItem { get; private set; }
        public object DroppedItem { get; private set; }
        public DragAndDropInfo(object sourceItem, object droppedItem)
        {
            SourceItem = sourceItem;
            DroppedItem = droppedItem;
        }
    }
