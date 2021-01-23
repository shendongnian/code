    var dte = (DTE)Marshal.GetActiveObject(string.Format(CultureInfo.InvariantCulture, "VisualStudio.DTE.{0}.0", targetVsVersion));
    MessageFilter.Register();
    var projects = dte.Solution.OfType<Project>().ToList();
    MessageFilter.Revoke();
    foreach (var proj in projects)
    {
       Debug.WriteLine(proj.Name);
    }
