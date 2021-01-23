    var context = TaskScheduler.FromCurrentSynchronizationContext();
    Task.Run(() =>
        {
            Program.move(File, _destinationFolder.SelectedPath + System.IO.Path.GetFileName(File),
                (fileCounter++).ToString() + " / " + FileList.Length.ToString());
            Trace.write(File);
        }).ContinueWith((task) =>  ++_totalProcessFileProgressBar.Value, context);
