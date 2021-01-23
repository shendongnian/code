    foreach (MyEntity myEntity in entities)
    {
      MyEntity backup = myEntity;
      myEntity.timer.AutoReset = true;
      myEntity.timer.Elapsed += (sender, arguments) => this.EntityTimeElapsed(sender, backup);
      myEntity.timer.Start();
    }
