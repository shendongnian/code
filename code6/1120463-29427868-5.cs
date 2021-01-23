    public async Task<ActionResult> Index(ManageMessageId? message)
    {
       ViewBag.StatusMessage = (message.HasValue)
          ? _messageDictionary[message.Value]
          : "";
