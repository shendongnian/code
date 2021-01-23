    private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        {
            // Get a handle for the to-do item bound to the button.
            ToDoItem toDoForDelete = button.DataContext as ToDoItem;
            // Remove the to-do item from the local database.
			App.ViewModel.DeleteToDoItem(toDoForDelete); 
            this.Focus();           
        }
    }
 
