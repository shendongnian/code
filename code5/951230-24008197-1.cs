    public ActionResult AddTruckExpensesTransactionChild(string totaldays, string amount)
       {
            string Mess = objActive.Save();
            if (Mess == "1")
                  return Json(new { Url = Url.Action("GetTruckExpensesChild", new { id = "", sid = "" }) });
            
            return Json(Mess, JsonRequestBehavior.AllowGet);
       }
