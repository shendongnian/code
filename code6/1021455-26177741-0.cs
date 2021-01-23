    public List<LogEntry> GetLogs(Expression<Predicate<LogEntry>> where)
    {
        return _Db.Logs.Where(where).ToList();
    }
}
