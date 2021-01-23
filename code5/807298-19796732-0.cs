    System.Diagnostics.Process
    Process[] allProcesses = Process.GetProcesses();
    processName = <Todo: check process_name in the array for word document>
    Regex r = WildcardToRegex(processName);
    matching = allProcesses.Where((p) =>
                {
                    try
                    {
                        return r.IsMatch(p.MainModule.FileName);
                    }
                    catch
                    {
                        return false;
                    }
                }).Select((p) => p.Id);
