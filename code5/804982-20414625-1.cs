    public string GetStatus(Runner selectedRunner)
    {
        if (selectedRunner.HasFinished == true)
        {
            return "Runner has already finished!";
        }
    }
