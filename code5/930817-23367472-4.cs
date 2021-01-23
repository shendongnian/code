    public ViewResult Details(int id)
    {
        var f = repository.AllFindDetails_J(id);
        List<string> ports = new List<string>();
        foreach(var p in f.CS.ITFirewalls)
        {
            ports.Add(p.CSPort);
        }
        foreach (var p2 in f.CS.ITRouters)
        {
            ports.Add(p2.CSPort);
        }
        foreach (var p3 in f.CS.ITSwitches)
        {
            ports.Add(p3.CSPort);
        }
        ports.Sort();
        f.AssignedPorts = ports;
        return View(f);
    }
