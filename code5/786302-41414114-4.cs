    public ActionResult Details(int Id)
        {            
            BussinceLogicLayer.UploadedFileBLL uploadBLL = new BussinceLogicLayer.UploadedFileBLL();
            var details = uploadBLL.Details(Id).ToList();
            return View(details);
        }
    
