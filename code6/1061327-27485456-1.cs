    public bool ProcessData(IProcessNotifier notifier)
    {
        if (notifier == null)
            throw new ArgumentNullException("notifier");
        notifier.AppendNotification("Init.", "Students");
        ProcessStudents(notifier);
        notifier.AppendNotification("Init.", "Parents");
        ProcessParents(notifier);
        notifier.AppendNotification("Init.", "Teachers");
        ProcessTeachers(notifier);
        notifier.AppendNotification("Init.", "Others");
        ProcessOthers(notifier);
    }
