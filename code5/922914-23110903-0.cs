     public void AddTask(Attempt objAtempt)
        {
            List<Attempt> attempts = new List<Attempt>();
            objAtempt.Id = Guid.NewGuid();
            objAtempt.Time = DateTime.Now;
            objAtempt.AttemptsMetaData = "test";
            objAtempt.Answered = true;
            objAtempt.Disconnected = DateTime.Now;
            attempts.Add(objAtempt);
        }
