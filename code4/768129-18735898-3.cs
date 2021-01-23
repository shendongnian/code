    using Microsoft.Phone.Controls;
    ....
    private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
    {
        var item = sender as MenuItem;
        if (item!= null)
        {
            // Get a handle for the to-do item bound to the button.
            ToDoItem toDoForDelete = item .DataContext as ToDoItem;
            App.ViewModel.DeleteToDoItem(toDoForDelete);
            MessageBox.Show("Deleted Successfully");
        }
        // Put the focus back to the main page.
        this.Focus();
    }
