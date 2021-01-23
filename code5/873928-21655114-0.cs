    private readonly IProcessValidation _validation;
    private readonly IExecuteCommands _commands;
    [HttpPost]
    public async Task<RedirectToRouteResult> Edit(short id, UpdateOffice command) {
        // with FV.NET plugged in, if your command validator fails,
        // ModelState will already be invalid
        if (!ModelState.IsValid) return View(command);
        _commands.Execute(command);
        return RedirectToAction(orWhateverYouDoAfterSuccess);
    }
