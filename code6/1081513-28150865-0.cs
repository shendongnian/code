    class Step 
    {
        public string Name { get; set; }
        public Action Action { get; set; }
    }
    var steps = new []
    {
        new Step() { Name = "Open the page", Action = OpenThePageStep },
        new Step() { Name = "Click links button", Action = ClickLinksBtnStep },
        ...
    };
    ...
    var id = 0; // or the Step class itself should have an id?
    foreach (var step in steps)
    {
        try
        {
            id++;
            step.Action();
        }
        catch (Exception ex)
        {
            Assert.Fail(AppManager.RaiseError(id, step.Name, ex));
        }
    }
