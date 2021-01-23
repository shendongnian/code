    List<double> secondsPerSession = new List<double>();
    foreach (var session in sessions)
    {
        if (session.Count == 1)
            secondsPerSession.Add(0);
        else
        {
            double average = session.Skip(1)
                .Average(d => (d - session[0]).TotalSeconds);
            secondsPerSession.Add(average);
        }
    }
