    using System;
    using System.Management.Automations;
    ...
    using (var ps = PowerShell.Create()) {
        ps.AddScript(@"Get-ChildItem c:\");
        var results = ps.Invoke();
        foreach (dynamic result in results) {
            ...
        }
    }
