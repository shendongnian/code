        string instanceName = "message read rate [ process id 1776 ]";
        string expression = @".*process id (?<PROCESS_ID>\d+).*";
        Match match = Regex.Match(instanceName, expression);
        if (match.Success)
        {
            string processId = match.Groups["PROCESS_ID"].Value.Trim();
            Console.WriteLine("Process ID is {0}", processId);
        }
        else
        {
            Console.WriteLine("Could not find process id");
        }
