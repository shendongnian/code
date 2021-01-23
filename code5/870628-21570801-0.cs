    [ChildActionOnly]
    public PartialViewResult UserInfo()
    {
        var viewModel = new LogonInfoViewModel
        {
            Fullname = "Patrick Peters"
        };
        return PartialView("_LoginInfo", viewModel); // <-- change is in this line
    }
