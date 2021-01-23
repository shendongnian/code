    return GetQuery(filterExpression, Columns)
       .Where(x => ProcessId.Any(processIdItem => processIdItem == x.ProcessID || processIdItem == x.ParentProcessId ))
       .OrderBy<Models.tblProcess>(sortExpression)
       .Skip(startRowIndex)
       .Take(maximumRows);
