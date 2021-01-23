    class Processor 
    {
        // note the use of interface instead of actual form
        public void UpdateWindow(IDynamicView view)
        {
            view.Text = "hello";
            view.AddItemToControlList( some item );
        }
    }
