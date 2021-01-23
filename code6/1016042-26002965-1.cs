    List<string> prevSalts = new List<string>();
    try
    {
        ...
    }
    catch (Exception ex)
    {
        prevSalts.Clear();
        prevSalts.Add("failure");     
    }
    return Json(new 
    {
        salts = prevSalts
    }, JsonRequestBehavior.AllowGet);
