    int a = 0;
    var context = TaskScheduler.FromCurrentSynchronizationContext();
    var task = new Task(() =>
    {
        Encode(listFrames, a);
    },
    _cancellationToken.Token);
    
    //Unique ID.
    a = task.Id;
    //Adds the item to the list.
    var encoderItem = new EncoderListViewItem
    {
        Image = (UIElement)Resources["Image"],
        Text = "Starting",
        Percentage = 0,
        Id = a
    };
    EncodingListBox.Items.Add(encoderItem);
    _taskList.Add(task);
    _taskList.Last().Start();
