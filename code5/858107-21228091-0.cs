    public static void UpdateCheckList(List<CheckListRequest> checkList)
    {
        foreach (CheckListRequest clr in checkList)
        {
            CheckListRequest clrInDB = dbContext.CheckListRequests.Where(o.Id == clr.Id).SingleOrDefault();
            clrInDB.IsChecked = clr.IsChecked;
            clrInDB.Comment = clr.Comment;
        }
        dbContext.SaveChanges();
    }
