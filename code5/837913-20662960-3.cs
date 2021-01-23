    class Processor 
    {
        public void UpdateWindow(DynamicForm form)
        {
            form.Text = "Title";
            UpdateListView(form.ControlList); 
            ...
        }
        public void UpdateListView(ListView listView)
        {
            listView.Clear();
            listView.AddItem(...)
        }
    }
