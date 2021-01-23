    private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
    {
        // Get a handle for the to-do item bound to the button.
        ToDoItem toDoForDelete = button.DataContext as ToDoItem;
        App.ViewModel.DeleteToDoItem(toDoForDelete);
        MessageBox.Show("Deleted Successfully");
        // Put the focus back to the main page.
        this.Focus();
    }
