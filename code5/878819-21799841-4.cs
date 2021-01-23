    public ActionResult Details()//string userTo, string userFrom)
    {
        var MsgHistory = PrivateMessageRepository.GetMessageHistoryByID(userTo, userFrom);
        var viewModel = MsgHistory.Messages.Select(x => new { x.UserFrom, x.Message }).ToList();
        return View(viewModel);   
    }
