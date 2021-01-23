    var item = (profileLists[indexPath.Row] as QuickSearchProfile);
    var result =  search.GetQuickSearchProfile(item);
            //    FillTable(result);
              //  TableView.ReloadData();
    var controller = (CommonTableView)this.Storyboard.InstantiateViewController("commonstoryboard");
    var commonTableView = new CommonTableView(controller.Handle);
    commonTableView.profileLists.AddRange(result);
    NavigationController.PushViewController(commonTableView, true);
