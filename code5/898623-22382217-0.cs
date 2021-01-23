    public ActionResult ReplaceFORATVersion()
    {
        string file_name = "C:\\Calculation Engine FORAT.xls";
        excelObj.Content = File.ReadAllBytes(fileName);
        db.SaveChanges();
        return RedirectToAction("Index", "AdminData");
    }
