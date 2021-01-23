    [HttpGet]
    public PartialViewResult AddTimeSheetRow(int day, int index)
    {
        string prefix = "";
        switch(day)
        {
            case 1:
            prefix = "Monday[" + index + "]"
            break;
            //do the same for other 4 days but change the day name
        }
        ViewData.TemplateInfo.HtmlFieldPrefix = prefix;
        return PartialView("_TimeSheetEntry", new TimeSheetEntry());
    }
