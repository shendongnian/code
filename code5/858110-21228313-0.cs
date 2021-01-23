    public static void UpdateCheckList(List<CheckListRequest> checkList)
    {
        checkList.foreach(CL =>{
                  CheckListRequest objCLR= DataContext.CheckListRequests
                  .SingleOrDefault(E => E.Id == CL.Id);
            objCLR.IsChecked = CL.IsChecked;
            objCLR.Comment = CL.Comment;
            });
    
        DataContext.SaveChanges();
    }
