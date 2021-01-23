       public IEnumerable<ITEye.ViewModels.IssueViewModel> Issue()
        {
            var issued = from item in db.Items
                        join issues in db.Issues on item.ItemId equals issues.ItemId
                        join users in db.Staffs on issues.StaffId equals users.StaffId
                        where issues.StaffId == users.StaffId
    
                         select new IssueViewModel()
                        {
                            ItemId = item.ItemId,
                            Name = item.ItemName,
                            ItemLocation = item.Location.LocName,
                            UserName = users.StaffName
                        };
    
            return issued.ToIEnumerable();
        }
