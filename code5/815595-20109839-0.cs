    progressbar1.Style = ProgressBarStyle.Marquee; //thanks Hamlet
    progressbar1.MarqueeAnimationSpeed = 30;
    //run the long running thing on a background thread.
    var bgTask = Task.Factory.StartNew(() => db.Database.ExecuteSqlCommand("myquery"));
    //when it's done, back on this thread, let me know and we'll turn the progress bar off
    bgTask.ContinueWith(resultTask => {
        progressBar1.Style = ProgressBarStyle.Continuous;
        progressBar1.MarqueeAnimationSpeed = 0;
     }, TaskScheduler.FromCurrentSynchronizationContext());
