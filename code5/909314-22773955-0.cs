    var dte = (EnvDTE.DTE)GetService(typeof(EnvDTE.DTE));
    if (dte != null)
    {
        var solution = dte.Solution;
        if (solution != null)
        {
            // get your projects here
        }
    }
