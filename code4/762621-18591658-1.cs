    foreach (MyEntity myEntity in entities)
    {
        var myEntity2 = myEntity ;
        myEntity2.timer.AutoReset = true;
        myEntity2.timer.Elapsed += (sender, arguments) => this.EntityTimeElapsed(sender, myEntity2);
        myEntity2.timer.Start();
