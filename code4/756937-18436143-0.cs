    private MobileServiceCollection<TodoItem, TodoItem> items;
    private IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();
    private async void InsertTodoItem(TodoItem todoItem)
        {
            // This code inserts a new TodoItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await todoTable.InsertAsync(todoItem);
            items.Add(todoItem);
        }
