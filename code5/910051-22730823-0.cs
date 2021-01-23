    public static WeekendReportResult CalculateWeekendReportResult(string dataFilPath, Action<string> del)
        {
            string newFile = CopyFile(dataFilPath);
           del(newFile);
            RemoveNotUsedFiles(dataFilPath, newFile);
            return ReadCalculations<WeekendGasReportResult>(newFile);
        }
