    public ActionResult Details()//string userTo, string userFrom)
    {
        var MsgHistory = PrivateMessageRepository.GetMessageHistoryByID(userTo, userFrom);
        var viewModel = MsgHistory.Messages.ToList();
        return View(viewModel);   
    }
