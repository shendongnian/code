    var dte = GetDTE(System.Diagnostics.Process.GetProcesses().Where(x => x.MainWindowTitle.StartsWith("SolutionName") && x.ProcessName.Contains("devenv")).FirstOrDefault().Id);
    MessageFilter.Register();
    var projects = dte.Solution.OfType<Project>().ToList();
    MessageFilter.Revoke();
    foreach (var proj in projects)
    {
       Debug.WriteLine(proj.Name);
    }
    Marshal.ReleaseComObject(dte);
