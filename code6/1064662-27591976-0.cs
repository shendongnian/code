    DateTime entryTime = DateTime.Parse("11:30");
    DateTime exitTime = DateTime.Parse("14:30");
    TimeSpan breakSpan = TimeSpan.Parse("0:30");
    var workSpan = new TimeSpan(exitTime.Ticks - entryTime.Ticks - breakSpan.Ticks);
    answerLabel.Text = workSpan.ToString();
