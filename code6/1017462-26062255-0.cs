    protected override void OnActivate()
    {
        base.OnActivate();
        var res = _service.GetPresons();
        Persons.Clear();
        Persons.AddRange(res);
    }
