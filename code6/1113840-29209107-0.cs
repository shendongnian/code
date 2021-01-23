    List<string> result = new List<string>
    foreach (App y in applications)
    {
        //Check if the app has a server listed and for duplicates
        if (y.Server != "" && !result.Contains(y.Server)
        {
                result.Add(y.Server)
        }
    }
    result.ForEach(x => vm_modal.serverLocations.Add(
                    new SelectListItem(){Text = x, Value = x}));
