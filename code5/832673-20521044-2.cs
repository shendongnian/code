    private void loadTaskList() //Call every X time
    {
        List<myObject> myList = myquery();
        this.Dispatcher.Invoke((Action)(() =>
        {
            TaskListTable.Items.Clear(); //Clear the DataGrid
            foreach (myObject O in myList) //Add the items from the new query.
            {
                TaskListTable.Items.Add(O);
            }
            // The items of the grid have changed, NOW we QUEUE the FindSelectionObject
            // operation on the dispatcher.
            FindSelectionObject(); // <-- (( MOVE IT HERE )) !!
        }));
    }
