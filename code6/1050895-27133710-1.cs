    var list = matchingHoleInfoVm.ToolHeader;
    for (int i = 0; i < list.Count; i++)
    {
        if (list[i].ToolID == notSelectedToolId)
        {
            list[i] = new ToolHeaderViewModel();
        }
    }
