    Thread trdGenerateTrajectory = new Thread(() => 
    {
        HeavyMethod();
        this.Invoke(new Action(() =>
        {
             // Update UI here.
        }));
    });
    trdGenerateTrajectory.Start();
    // trdGenerateTrajectory.Join(); <- do not block
