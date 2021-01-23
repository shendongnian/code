    public class ExtendedGridSplitter : GridSplitter
    {
    ...
        public ExtendedGridSplitter()
        {
            EventManager.RegisterClassHandler(typeof(ExtendedGridSplitter), Thumb.DragDeltaEvent,
                new DragDeltaEventHandler(OnDragDelta));
        }
    ...
        private void OnDragDelta(object sender, DragDeltaEventArgs e)
        {        
            e.Handled = true;           
        }
    }
