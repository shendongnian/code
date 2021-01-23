    public static void UpdateCheckList(List<CheckListRequest> checkList)
    {
        foreach (CheckListRequest clr in checkList)
        {
            CheckListRequest clrInDB = dbContext.CheckListRequests.SingleOrDefault(o.Id == clr.Id);
            clrInDB.IsChecked = clr.IsChecked;
            clrInDB.Comment = clr.Comment;
        }
        dbContext.SaveChanges();
    }
