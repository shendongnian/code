    foreach(var kvp in waytosave.OrderBy(key => key.Value))
    {
        var timer = new System.Windows.Forms.Timer();
        int track = 1;
        timer.Tick += (timerObject, timerArgs) =>
        {
            timer.Interval = track * kvp.Value *1000;
            ...
