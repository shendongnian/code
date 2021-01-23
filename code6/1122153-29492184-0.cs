    public void Save()
    {
        var builder = new StringBuilder()
        foreach (IAppointment item in _appointments)
        {
            builder.AppendLine(item.Start);
            builder.AppendLine(item.Length);
            builder.AppendLine(item.DisplayableDescription);
            builder.AppendLine(" ");
        }
        File.WriteAllText("appointments.txt", builder.ToString());
    }
