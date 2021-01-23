    public ActionResult ChangeFilterList(int option)
    {
        var data = new[] 
        { 
            new MyViewModel { Text = "Unknown option", Value = -1 } 
        };
        switch (option)
        {
            case 2: data = _departmentnameRepository
                .All
                .Select(x => new MyViewModel { Text = x.DeptName, Value = x.Id })
                .ToArray();
                break;
            case 3: data = Session["projectid"] == null
                    ? _assetSequenceRepository
                        .All
                        .Select(x => new MyViewModel { Text = x.AssetShotName, Value = x.Id })
                        .ToArray()
                    : _assetSequenceRepository
                        .FindBy(p => p.ProjectId == (int)Session["projectid"])
                        .Select(x => new MyViewModel { Text = x.AssetShotName, Value = x.Id })
                        .ToArray();
                break;
            default: data = _userRepository
                .All
                .Select(x => new MyViewModel { Text = x.DisplayName, Value = x.UserID })
                .ToArray();
                break;
        }            
    
        return Json(data, JsonRequestBehavior.AllowGet);
    }
