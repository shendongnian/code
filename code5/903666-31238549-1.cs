    string ThisDir = "E:/AjkerDealLatest/images/Deals";
    System.IO.Directory.CreateDirectory(ThisDir + "\\" + FolderNameHiddenField.Value);
    ImageName = Request.Form.GetValues("name");
    string path = Path.Combine("E:/AjkerDealLatest/images/Deals/"+ FolderNameHiddenField.Value, ImageName[0] + ".jpg");
    
    file.SaveAs(path);
