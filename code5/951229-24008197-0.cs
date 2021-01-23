    public ActionResult AddTruckExpensesTransactionChild(string totaldays, string amount)
       {
            string Mess = objActive.Save();
            if (Mess == "1")
            {
                return RedirectToAction("GetTruckExpensesChild", new { id="", sid="" });
            }
            return Json(Mess, JsonRequestBehavior.AllowGet);
       }
